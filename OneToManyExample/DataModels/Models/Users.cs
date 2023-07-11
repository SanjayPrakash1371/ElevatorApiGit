using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Users
    {

        public Users()
        {
            this.accounts=new HashSet<Accounts>();
        }

       
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public virtual ICollection<Accounts> accounts { get; set; }
    }
}
