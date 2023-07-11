using Microsoft.EntityFrameworkCore;
using Sample.Models;
using Sample.Models.P2P;

namespace Sample.DbConnect
{
    public class AllDataAccess:DbContext
    {
        public AllDataAccess(DbContextOptions<AllDataAccess> options):base(options) { }

        public DbSet<Employee> Employees { get; set; }  

        /*public DbSet<Employee_login> Employees_login { get; set;}*/

        public DbSet<Roles> Roles { get; set; }

        public DbSet<PeerToPeer> PeerToPeer { get; set; }

        public DbSet<PeerToPeerResults> PeerToPeerResults { get; set;}
        
    }
}
