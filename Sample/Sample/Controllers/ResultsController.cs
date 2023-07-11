using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.DbConnect;
using Sample.Models.P2P;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {

        private readonly AllDataAccess dataAccess;
        public ResultsController(AllDataAccess dataAccess) { this.dataAccess = dataAccess; }

        [HttpGet]
        [Route("{count}")]

        public async Task<ActionResult<IEnumerable<PeerToPeerResults>>> getResult([FromRoute] int count)
        {

            var arr = dataAccess.PeerToPeerResults.GroupBy(p => p.nomainatedEmpId);

            var result = (from l in arr select new {Id=l.Key, Nominations=l.ToList().Count() }).OrderByDescending(x=>x.Nominations).Take(count) ;


            return Ok(result);


        }


    }
}
