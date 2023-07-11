using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public class UserPassword
    {

        public int id { get; set; }
        [Required]

        public string email { get; set; }
       
        [Required]
        public string Password { get; set; }

      //  public Employee? Employee { get; set; }
    }
}
