using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http;
using WEBAPIPRACTICE.App_Code;
using WEBAPIPRACTICE.Models;

namespace WEBAPIPRACTICE.Controllers
{
    public class PeopleController : ApiController
    {
        // GET: api/People/




        //public PeopleController()
        //{
        //    people.Add(new Person { FirsName = "Tim", LastName = "Corey", Id = 1 });
        //    people.Add(new Person { FirsName = "Sue", LastName = "Storm", Id = 2 });
        //    people.Add(new Person { FirsName = "Bilbo", LastName = "Baggins", Id = 3 });
        //}

        /// <summary>
        /// Gets a list of the first names of all users
        /// </summary>
        /// <param name="userId"> The unique identifier for this persons</param>
        /// <param name="age"> We wan to know how old they are </param>
        /// <returns>list of first names</returns>
        //[Route("api/People/GetFirstNames/{userId:int}/{age:int}")]
        //[HttpGet]
        //public List<string> GetFirstNames(int userId, int age)
        //{
        //    List<string> output = new List<string>();

        //    foreach (var p in people)
        //    {
        //        output.Add(p.FirsName);
        //    }

        //    return output;
        //}


      
        public List<Person> Get()
        {
            var list = new List<Person>();

            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"Select Id, Firstname,Lastname FROM Person";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new Person
                            {


                                Id = int.Parse(dr["Id"].ToString()),
                                FirstName = dr["Firstname"].ToString(),
                                LastName = dr["Lastname"].ToString(),



                            });
                        }
                    }
                    con.Close();
                }
            }


            return list;
        }


        public Person Get(int id)
        {
            var record = new Person();


            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();

                string query = @"Select Id, Firstname,Lastname FROM Person where Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {

                                record.Id = int.Parse(dr["Id"].ToString());
                                record.FirstName = dr["Firstname"].ToString();
                                record.LastName = dr["Lastname"].ToString();


                            }


                        }

                    }
                }


            }

            return record;
        }   

        public IHttpActionResult Put(Person person)
        {
            using(SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"Update Person 
                    Set Firstname =  @PersonFirstName, Lastname = @PersonLastname Where Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", person.Id);
                    cmd.Parameters.AddWithValue("@PersonFirstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@PersonLastname", person.LastName);
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }

            return Ok();
        }


        //Get action methods of the previous section

        public void Post(Person val)
        {
      
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"INSERT INTO Person 
                    VALUES(@PersonFirstName, @PersonLastname)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PersonFirstName", val.FirstName);
                    cmd.Parameters.AddWithValue("@PersonLastname", val.LastName);
                    cmd.ExecuteNonQuery();
                }   

                con.Close();
            }

     

        }

        //------------------------




        



    }

}
