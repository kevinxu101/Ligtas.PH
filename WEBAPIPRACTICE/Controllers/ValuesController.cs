using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEBAPIPRACTICE.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        

        //GET AND POST is the same URL but differ in protocol
        //AND the GET API/ID is the same for  GET PUT AND DELETE  


        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5



        //Get is like the Read in Crud ~ get information essentially select star from  table
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values



        // POST is like the create in CRUD
        // create a new record or insert a new vlaue
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        //Put is like the UPdate ~  modify a a record that is already exist
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
