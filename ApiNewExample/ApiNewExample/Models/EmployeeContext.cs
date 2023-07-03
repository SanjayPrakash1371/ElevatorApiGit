using Microsoft.EntityFrameworkCore;

namespace ApiNewExample.Models
{
    public class EmployeeContext:DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { 
        
        
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LiftLogger> liftLoggers { get; set; }
    }
}
