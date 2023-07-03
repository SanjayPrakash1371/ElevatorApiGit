using Microsoft.EntityFrameworkCore;

namespace CrudExampleEF.Models
{
    public class StudentContext:DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> option):base(option)
        {
            

        }
        public DbSet<Student> Students { get; set; }

        // TO create different table mention here
    }
}
