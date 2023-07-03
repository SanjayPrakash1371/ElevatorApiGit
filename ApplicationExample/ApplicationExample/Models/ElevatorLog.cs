using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationExample.Models
{
    public class ElevatorLog
    {
        public int id { get; set; } 
        public int floorno { get; set; }
        public int weight { get; set; }
        public DateTime time { get; set; }
    }
}