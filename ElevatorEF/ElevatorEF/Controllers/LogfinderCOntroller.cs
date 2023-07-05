using DataAccess.DbAccess;
using ElevatorEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace ElevatorEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogfinderCOntroller : ControllerBase
    {
        private readonly AllDbContext context;

        public LogfinderCOntroller(AllDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElevatorLogDI>>> Get()
        {
            var result= await context.elevatorLoggings.ToListAsync();

            result.ForEach(x =>
            {
                x.liftlog = context.LiftLogs.Find(x?.liftlog?.id);
                x.ElevatorLogAccess = context.ElevatorLogs.Find(x?.ElevatorLogAccess?.Id);

            });
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ElevatorLogDI>> getById([FromRoute] int id)
        {
            var result = await context.elevatorLoggings.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> add(CurrentLog log)
        {
            ElevatorLogDI di = new ElevatorLogDI();
            LiftLog? logger= context.LiftLogs.FirstOrDefault(x => x.id == log.logId);
            di.liftlog = logger;

            ElevatorLogAccess? access = context.ElevatorLogs.FirstOrDefault(x => x.Id == log.elevatorLogId);
            di.ElevatorLogAccess = access;

            await context.elevatorLoggings.AddAsync(di);
            await context.SaveChangesAsync();

            return Ok(di);
        }
        
    }
}
