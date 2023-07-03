using ElevatorEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElevatorEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiftController : ControllerBase  
    {
        private readonly AllDbContext context;
        public LiftController(AllDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LiftLog>>> Get()
        {

            return await context.LiftLogs.ToListAsync();

        }

        [HttpGet]
        [Route("{id}")]
        public  async Task<ActionResult<LiftLog>> Get([FromRoute] int id)
        {
            return await context.LiftLogs.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<LiftLog>> Post(NewLog newlog)
        {
            if(newlog== null)
            {
                return BadRequest();
            }
            LiftLog log = new LiftLog();
            log.empId = newlog.empId;
            log.start=newlog.start;
            log.end=newlog.end;
            log.dateTime = DateTime.Now;

           await context.LiftLogs.AddAsync(log);
            await context.SaveChangesAsync();

            return Ok(log);
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> delete([FromRoute] int id)
        {
            var result=context.LiftLogs.FirstOrDefaultAsync(l=>l.id==id);   

            if(result==null)
            {
                return NotFound();
            }

             context.Remove(result);
            await context.SaveChangesAsync();

            return Ok(result);
        }
    }
}
