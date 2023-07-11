using AuthenticationExample.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationExample.AllDbContext
{
    public class AllDataAccess:DbContext
    {

        public AllDataAccess(DbContextOptions<AllDataAccess> options):base(options) 
        {
            
        }

        public  DbSet<Users> users { get; set; }

        public   DbSet<Employee> employees { get; set; }
    }
}
