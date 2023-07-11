using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.AllDbAccess
{
    public class AllDbContext:DbContext
    {
        public AllDbContext(DbContextOptions<AllDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Accounts> Accounts { get; set; }


       
    }
}
