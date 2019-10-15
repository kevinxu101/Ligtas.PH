using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEBAPIPRACTICE.Models;

namespace WEBAPIPRACTICE.Controllers
{
    public class HomeController : Controller
    {
        //Main Page


          
        public ActionResult Index()
        {
            var webClient = new WebClient();

            var json = webClient.DownloadString(@"http://localhost:51180/api/People");
            List<Person> list = JsonConvert.DeserializeObject<List<Person>>(json);


            return View(list);
        }

        //-----------------------------------   POST--------------------

        string url = "http://localhost:51180/api/People";


        HttpClient client;

        public ActionResult create()
        {
            var model = new Person();
            return View(model);
        }


        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        [HttpPost]
        public async Task<ActionResult> create(Person Emp)
        {

            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, Emp);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        //-----------------------------------   PUT --------------------

        public ActionResult Edit(int id)
        {
            Person student = null;

            using (var client = new HttpClient())
            {
     
                client.BaseAddress = new Uri("http://localhost:51180/api/");
                //HTTP GET
                var responseTask = client.GetAsync("People?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Person>();
                    readTask.Wait();

                    student = readTask.Result;
                }
            }
            return View(student);
        }


        [HttpPost]
        public ActionResult Edit(Person person)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51180/api/People");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Person>("People", person);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(person);
        }
    }
}


