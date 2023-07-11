using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public  class Accounts
    {

        /*public Accounts()
        {
            this.Users=new HashSet<Users>();
        }*/

        public int id { get; set; }

       
        public string type { get; set; }

        
        public double balance { get; set; }

        public Users? users { get; set; }

       // public virtual ICollection<Users> Users { get; set; }   
    }
}
