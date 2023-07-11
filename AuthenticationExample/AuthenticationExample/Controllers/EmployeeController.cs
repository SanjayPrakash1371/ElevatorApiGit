using AuthenticationExample.AllDbContext;
using AuthenticationExample.Authentication;
using AuthenticationExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace AuthenticationExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly AllDataAccess context;
        public EmployeeController(AllDataAccess context) { this.context = context; }

        [HttpGet]
        [BasicAuthentication]
        public async Task<ActionResult<IEnumerable<Employee>>>  Get()
        {
           return await context.employees.ToListAsync();
        }
    }
}
