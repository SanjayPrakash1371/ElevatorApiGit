using ElevatorEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ElevatorEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private readonly AllDbContext context;
        public ElevatorController(AllDbContext context)
        {
            this.context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevator>>> Get()
        {

            return await context.Elevators.ToListAsync();

        }

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<Elevator>> Get([FromRoute] int id)
        {
            var result = await context.Elevators.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]

        public async Task<IActionResult> addEmployee(AddElevator addelevator)
        {
           if(addelevator == null)
            {
                return BadRequest();
            }
            Elevator e = new Elevator();
            e.weight=addelevator.weight;
            e.floorno=addelevator.floorno;
            e.dateTime = DateTime.Now;
           await context.Elevators.AddAsync(e);
            await context.SaveChangesAsync();

            return Ok(e);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var eleSearch = context.Elevators.FirstOrDefault(x => x.Id.Equals(id));

            if (eleSearch != null)
            {
                // Remove from the storage
                context.Remove(eleSearch);
                // saves the result to the database
                await context.SaveChangesAsync();
            }

            return Ok(eleSearch);



        }
    }

    
}
