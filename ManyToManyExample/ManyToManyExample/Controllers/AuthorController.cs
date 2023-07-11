using DataAccess.AllDbContext;
using DataModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManyToManyExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AllDataAccess context;
        public AuthorController(AllDataAccess context)
        {
            this.context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
            //  return await context.Authors.ToListAsync();

            // var q = (from auth in context.Authors join book in context.books on auth. )

            var result = await context.Authors.ForEachAsync(x =>

            x.books = context.books.FirstOrDefaultAs(y => y.id == x.bookId)




                ) ;

            return Ok(result);
        }


        // one to many
        [HttpPost]
        public async Task<ActionResult<Books>> AddAuthor(Author author)
        {
            await context.Authors.AddAsync(author);

            await context.SaveChangesAsync();

            return Ok(author);
        }
    }
}
