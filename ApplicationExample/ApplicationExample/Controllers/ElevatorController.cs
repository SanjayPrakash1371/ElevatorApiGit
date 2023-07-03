using ApplicationExample.DataBaseConnections;
using ApplicationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Web.Http;
using System.Net.Http;

namespace ApplicationExample.Controllers
{
    public class ElevatorController : ApiController
    {
        DataContext dataContext= new DataContext();

        public List<ElevatorLog> Get()
        {
            //  var data = dataContext.getEmpByDt();

            return dataContext.getElevatorLogList();
           

           // return Request.CreateResponse(HttpStatusCode.OK, data);
        }


       

        // GET api/<controller>/5
        public ElevatorLog Get(int id)
        {
            return dataContext.getElevatorLogById(id);
        }

        // POST api/<controller>
        public string  Post([FromBody] ElevatorLog log)
        {

            return dataContext.addLiftlog(log);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}