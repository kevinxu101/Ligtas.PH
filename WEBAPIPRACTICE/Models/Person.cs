﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBAPIPRACTICE.Controllers;

namespace WEBAPIPRACTICE.Models
{
    public class Person
    {

        PeopleController people = new PeopleController();


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


       
 



    }
}