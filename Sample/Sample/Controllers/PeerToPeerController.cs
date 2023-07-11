using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
                x.employee = dataAccess.Employees.FirstOrDefault(emp => emp.empId.Equals(x.empId));
            });

            return Ok(result);
        }

        [HttpGet]
        [Route("{empId}")]

        public async Task<ActionResult<PeerToPeer>> get([FromRoute] string empId)
        {
            var result = await dataAccess.PeerToPeer.FirstOrDefaultAsync(x => x.nominatorId.Equals(empId));
            result.employee = dataAccess.Employees.FirstOrDefault(x => x.empId.Equals(empId));




            return Ok(result);
        }


        [HttpPost]

        public async Task<ActionResult<PeerToPeer>> AddAward(NewPeerToPeer p)
        {
            PeerToPeer p2 = new PeerToPeer();
            p2.nominatorId = p.nominatorId;

            p2.empId = p.empId;

            p2.awardCategory = p.awardCategory;

            p2.month = p.month;

            p2.citation = p.citation;

            //  p2.employee = dataAccess.Employees.Find(p.empId);
            PeerToPeerResults result = new PeerToPeerResults();
            result.nomainatedEmpId = p.empId;
            result.nomainaterId = p.nominatorId;
            result.citation = p.citation;

           

            Employee employee = await dataAccess.Employees.FirstOrDefaultAsync(x=>x.empId.Equals(p2.empId));
            result.employee = employee;


            p2.Results = result;
            p2.employee = employee;
            


            await dataAccess.PeerToPeer.AddAsync(p2);

            // await dataAccess.PeerToPeerResults.AddAsync(result);



            await dataAccess.SaveChangesAsync();

            return Ok(p2);
        }

        [HttpPut]
        [Route("{empId}")]
        public async Task<ActionResult<PeerToPeer>> updateUser([FromRoute] string empId,NewPeerToPeer p)
        {

            PeerToPeer pNew = dataAccess.PeerToPeer.FirstOrDefault(x=>x.empId.Equals(empId));

            pNew.nominatorId= p.nominatorId;
            pNew.empId = p.empId;
            pNew.citation = p.citation;
            pNew.awardCategory = p.awardCategory;

            //Add Employee
            Employee employee=dataAccess.Employees.FirstOrDefault(x=>x.empId.Equals(pNew.empId));
            pNew.employee = employee;

            PeerToPeerResults results=  dataAccess.PeerToPeerResults.FirstOrDefault(x => x.nomainaterId.Equals(pNew.nominatorId));

            results.nomainatedEmpId=pNew.empId;
            results.citation=pNew.citation;

            results.employee=employee;

            //Add Peer Results;

            pNew.Results = results;


             dataAccess.PeerToPeer.Update(pNew);

            await dataAccess.SaveChangesAsync();

            return Ok(pNew);


            /*if (EmployeeAvailable(empId))
            {
                PeerToPeer p2 = new PeerToPeer();
                p2.nominatorId = p.nominatorId;

                p2.empId = p.empId;

                p2.awardCategory = p.awardCategory;

                p2.month = p.month;

                p2.citation = p.citation;

                //  p2.employee = dataAccess.Employees.Find(p.empId);
                PeerToPeerResults? result = dataAccess.PeerToPeerResults.FirstOrDefault(x => x.nomainaterId == p2.nominatorId);
                if (result != null)
                {
                    result.nomainatedEmpId = p.empId;
                    result.nomainaterId = p.nominatorId;
                    result.citation = p.citation;





                }
              


                dataAccess.Update(p2);
                await dataAccess.SaveChangesAsync();
                return Ok(p2);
            }
            else
            {
                return BadRequest();
            }*/
        }
        private bool EmployeeAvailable(string empId)
        {
            return (dataAccess.Employees?.Any(x=>x.empId.Equals(empId))).GetValueOrDefault();
        }

    }
}
