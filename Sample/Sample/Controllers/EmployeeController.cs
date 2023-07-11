using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.DbConnect;
using Sample.Models;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AllDataAccess dataAccess;
        public EmployeeController(AllDataAccess dataAccess) { this.dataAccess = dataAccess; }

        [HttpPost]

        public async Task<ActionResult<Employee>> addEmployee(Employee employee)
        {
           
            await dataAccess.Employees.AddAsync(employee);

            await dataAccess.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> updateEmployee([FromRoute] string empId , Employee employee)
        {

            if(EmployeeAvailable(empId))
            {
                 dataAccess.Employees.Update(employee);

                await dataAccess.SaveChangesAsync();

                return Ok(employee);
            }
            else
            {
                return BadRequest();
            }

        }

        private bool EmployeeAvailable(string empId)
        {
            return (dataAccess.Employees?.Any(x => x.empId.Equals(empId))).GetValueOrDefault();
        }
    }
}
