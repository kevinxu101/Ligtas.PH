using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPIPRACTICE.Models
{
    public class Google
    {
        public int TitleID { get; set; }
        public string  Title  { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }
    }
}