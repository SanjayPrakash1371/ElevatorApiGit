using ApiNewExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiNewExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeContext employeeContext;
        public EmployeeController(EmployeeContext employeeContext)
        {


            this.employeeContext = employeeContext;

        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await employeeContext.Employees.ToListAsync();
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Employee>> Get(int id)
        {
            if (employeeContext.Employees == null)
            {
                return NotFound();
            }

            var result = await employeeContext.Employees.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]

        public async Task<ActionResult<Employee>> postEmployee(Employee emp)
        {
            employeeContext.Employees.Add(emp);
            await employeeContext.SaveChangesAsync();

            // return CreatedAtAction(nameof(Get), new { id = student.id }, student);

            return Ok(emp);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateEmployee([FromRoute] int id, Employee employee)
        {
         //   Employee result = employeeContext.Employees.FirstOrDefault(x => x.Id == id);

            if(EmployeeAvailable(id))
            {
                employeeContext.Employees.Update(employee);

                await employeeContext.SaveChangesAsync();

                return Ok(employee);
            }

            else
            {
                return NotFound(id);
            }
           

        }

        private bool EmployeeAvailable(int id)
        {
            return (employeeContext.Employees?.Any(x=>x.Id == id)).GetValueOrDefault();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            // Find the value by the id of the customer.
            var employeeSearch = employeeContext.Employees.FirstOrDefault(x => x.Id.Equals(id));

            if (employeeSearch != null)
            {
                // Remove from the storage
                employeeContext.Remove(employeeSearch);
                // saves the result to the database
                await employeeContext.SaveChangesAsync();
            }

            return Ok(employeeSearch);

        }

    }
}
