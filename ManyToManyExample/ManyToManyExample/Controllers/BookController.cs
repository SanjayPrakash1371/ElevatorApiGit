using DataAccess.AllDbContext;
using DataModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManyToManyExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AllDataAccess context;
        public BookController(AllDataAccess context)
        {
            this.context = context;
            
        }

        [HttpPost]
        public async Task<ActionResult<Books>> AddBook(Books books)
        {
           /* Books books = new Books();
            books.bookname = newbook.bookname;

            foreach(string name in newbook.authors){

                Author author = new Author();

                author.authorname = name;
                books.Authors.Add(author);

            }*/

            await context.books.AddAsync(books);

            await context.SaveChangesAsync();

            return Ok(books);

        }

        
    }
}
