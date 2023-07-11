using DataModels.Models;
using DbAccess.AllDbAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OneToManyExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AllDbContext context;

        public UserController(AllDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {

            var result = await context.Users.ToListAsync();

            var q = (from u in context.Users join ac in context.Accounts on u.id equals ac.users.id select new
            {
                u.name,
                ac.type,
                ac.balance
            }).ToListAsync();








            return Ok(q);

        }
        [HttpPost]

        public async Task<ActionResult<Users>> addEmployee(Users u)
        {
           
            await context.Users.AddAsync(u);
            await context.SaveChangesAsync();

            return Ok(u);
        }
    }
}
