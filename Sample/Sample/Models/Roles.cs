using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public class Roles
    {
        
        public int Id { get; set; }

        public string empId { get; set; }

        public string roles { get; set; }

        public Employee emp { get; set; }
    }
}
