using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AllDbContext
{
    public class AllDataAccess:DbContext
    {
        public AllDataAccess(DbContextOptions<AllDataAccess> options):base(options) { }

        public DbSet<Books> books { get; set; }

        public DbSet<Author> Authors { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().
                HasKey(ba => new { ba.bookId, ba.authorId });

            modelBuilder.Entity<BookAuthor>().
                HasOne(ba => ba.book).WithMany(ba => ba.Authors).HasForeignKey(ba=>ba.bookId);


            modelBuilder.Entity<BookAuthor>().
                HasOne(ba=>ba.author).WithMany(ba=>ba.books).HasForeignKey(ba=>ba.authorId);    

        }*/
        
    }
}
