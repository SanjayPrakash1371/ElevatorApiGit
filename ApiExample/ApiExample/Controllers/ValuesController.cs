using ApiExample.DatabaseConnections;
using ApiExample.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiExample.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        DataContext db = new DataContext();
        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {
            return db.getEmpByDt();

            
        }

        public  List<Employee> getAll()
        {
            var empList=new List<Employee>(db.get());

            return empList;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

           // Employee emp = db.getEmployeeById(id);


           // return JsonConvert.DeserializeObject<Employee>(db.getEmployeeById(id));

           // Employee emp= (db.getEmployeeById(id));
           
             return JsonConvert.SerializeObject(db.getEmployeeById(id));
          //   return db.getEmployeeById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value )
        {
            Employee emp = JsonConvert.DeserializeObject<Employee>(value);
           db.addEmployee(emp);




        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
