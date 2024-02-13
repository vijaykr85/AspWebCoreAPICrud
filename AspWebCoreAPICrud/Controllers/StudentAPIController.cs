using AspWebCoreAPICrud.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks; // Don't forget to add this using statement for Task

namespace AspWebCoreAPICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly DbContextOptions<StudentContext> options;

        public StudentAPIController(DbContextOptions<StudentContext> options)
        {
            this.options = options;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            using (var context = new StudentContext(options))
            {
                var data = await context.StudentsMarkseet.ToListAsync();
                return Ok(data);
            }

            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            using (var context = new StudentContext(options))
            {
                var student = await context.StudentsMarkseet.FindAsync(id);
                if (student == null)
                {
                    return NotFound(); 
                }
                return student;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            using (var context = new StudentContext(options))
            {
                await context.StudentsMarkseet.AddAsync(std);
                await context.SaveChangesAsync();
                return Ok(std);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            using (var context = new StudentContext(options))
            {
                if(id!=std.Id) 
                {
                    return BadRequest();
                }
                context.Entry(std).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(std);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            using (var context = new StudentContext(options))
            {
                var std = await context.StudentsMarkseet.FindAsync(id);
                if(std == null)
                {
                    return NotFound();
                } 
                context.StudentsMarkseet.Remove(std);
                await context.SaveChangesAsync();
                return Ok();
            }
        }


    }
}
