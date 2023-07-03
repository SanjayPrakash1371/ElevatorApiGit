using CrudExampleEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudExampleEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _studentContext;

        public StudentController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        /*[HttpGet]
         public  List<Student> GET()
         {
             return  _studentContext.Students.ToList();
         }*/
        // Task => Thread
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            if (_studentContext.Students == null)
            {
                return NotFound();
            }

            return await _studentContext.Students.ToListAsync();
        }

      /*  [HttpGet ("{id}")]

        public async Task<ActionResult<Student>> Get(int id)
        {
            if (_studentContext.Students == null)
            {
                return NotFound();
            }

            var result=await _studentContext.Students.FindAsync(id);

            if(result==null) {
                return NotFound();
            }

            return result;
        }*/

        [HttpGet("{id}")]
        public Student getStudentById(int id)
        {

            return _studentContext.Students.Find(id);
        }

        [HttpPost]
        public void addStudent(Student student)
        {
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
        }

        /*[HttpPost]

        public async Task<ActionResult<Student>> postStudent(Student student)
        {
            _studentContext.Students.Add(student);
            await _studentContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = student.id }, student);
        }*/
        [HttpPut]
        public async Task<IActionResult> updateStudent(int id, Student student)
        {
         //   LinQ Syntax to Search the element
         //   var result =_studentContext.Students.FirstOrDefault(x=>x.id == student.id);
        // _studentContext.Students.Update(result);
        //[Route("{id:guid}")]
            if (id != student.id)
            {
                return BadRequest();
            }
            _studentContext.Entry(student).State = EntityState.Modified;

            try
            {
                await _studentContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAvailable(id))
                {

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        private bool StudentAvailable(int id)
        {
            return (_studentContext.Students?.Any(x => x.id == id)).GetValueOrDefault();
        }

        /* [HttpPut]
         public void update(int id, Student student)
         {
             _studentContext.Entry(student).State = EntityState.Modified;
             _studentContext.SaveChanges();

         }*/

        [HttpDelete]

        public async Task<IActionResult>deleteStudent(int id)
        {
            if(_studentContext.Students == null)
            {
                return NotFound();
            }
            var student= await _studentContext.Students.FindAsync(id);

            if(student==null)
            {
                return NotFound();
            }

            _studentContext.Students.Remove(student);

            await _studentContext.SaveChangesAsync();

            return Ok(student);
        }


    }
}
