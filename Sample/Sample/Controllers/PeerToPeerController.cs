using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.DbConnect;
using Sample.Models;
using Sample.Models.P2P;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeerToPeerController : ControllerBase
    {
        private readonly AllDataAccess dataAccess;
        public PeerToPeerController(AllDataAccess dataAccess) { this.dataAccess = dataAccess; }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PeerToPeer>>> get()
        {
            var result = await dataAccess.PeerToPeer.ToListAsync();

            result.ForEach(x =>
            {
                x.employee = dataAccess.Employees.Find(x.empId);
            });

            return Ok(result);
        }


        [HttpPost]

        public async Task<ActionResult<PeerToPeer>> AddAward(NewPeerToPeer p)
        {
            PeerToPeer p2 = new PeerToPeer();
            p2.nominatorId = p.nominatorId;

            p2.empId = p.empId;

            p2.awardCategory = p.awardCategory;

            p2.month=p.month;

            p2.citation=p.citation;

          //  p2.employee = dataAccess.Employees.Find(p.empId);
            PeerToPeerResults result  = new PeerToPeerResults();
            result.nomainatedEmpId = p.empId;
            result.nomainaterId = p.nominatorId;
            result.citation = p.citation;

            p2.Results = result;


            await dataAccess.PeerToPeer.AddAsync(p2);

           // await dataAccess.PeerToPeerResults.AddAsync(result);



            await dataAccess.SaveChangesAsync();

            return Ok(p2);
        }
    }
}
