using ApplicationExample.DataBaseConnections;
using ApplicationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationExample.Controllers
{
    public class ValuesController : ApiController
    {

        DataContext db = new DataContext();
        // GET api/values
        public List<Employee> Get()
        {

           // return db.get();
            return db.get();
        }

        // GET api/values/5
        public Employee Get(int id)
        {
            return db.getEmployeeById(id);
        }

        // POST api/values
        public void Post([FromBody] Employee employee)
        {

            db.addEmployee(employee);
        }

        // PUT api/values/5
        public string Put(int id, [FromBody] Employee employee)
        {
            return db.updateEmployee(id, employee);
        }

        // DELETE api/values/5
        public string  Delete(int id)
        {
            return db.deleteEmployee(id);
        }
    }
}
