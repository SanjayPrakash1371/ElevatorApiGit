using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationExample.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        public int officeFloor { get; set; }
    }
}