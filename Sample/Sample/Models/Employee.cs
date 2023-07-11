using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        
        public string empId { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }
    }
}
