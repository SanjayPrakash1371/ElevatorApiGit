using DataAccess.DbAccess;
using ElevatorEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElevatorEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AllDbContext context;

        public EmployeeController(AllDbContext context) {
            this.context = context;
        
        }

        [HttpGet]
        public  async Task<ActionResult<IEnumerable<Employee>>> Get()
        {

            var result= await context.Employees.ToListAsync();

           

            

            return Ok(result);

        }

        [HttpGet]
        [Route("{id}")]

        public  async Task<ActionResult<Employee>> Get([FromRoute] int id)
        {
            var result= await context.Employees.FirstOrDefaultAsync(x=>x.Id==id);

            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<Employee>> addEmployee(Employee employee)
        {
            if(employee==null)
            {

                return BadRequest();
            }

            await context.Employees.AddAsync(employee);

            await context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<ActionResult<Employee>> updateEmployee([FromRoute] int id, Employee employee)
        {
           if(EmployeeAvailable(id))
            {
                 context.Employees.Update(employee);
                await context.SaveChangesAsync();

                return Ok(employee);

            }
            else
            {
                return NotFound();
            }
        }
        private bool EmployeeAvailable(int id)
        {
            return (context.Employees?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var empSearch = context.Employees.FirstOrDefault(x => x.Id.Equals(id));

            if (empSearch != null)
            {
                // Remove from the storage
                context.Remove(empSearch);
                // saves the result to the database
                await context.SaveChangesAsync();
            }

            return Ok(empSearch);



        }


    }
}
