
using Microsoft.AspNetCore.Mvc;
using UniversityManagement.Data;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly UniversityDbContext _context;

        public StudentController(UniversityDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult Get()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

       
        [HttpPost]
        public IActionResult Post(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(student);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student model)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            student.FullName = model.FullName;
            _context.SaveChanges();

            return Ok(student);
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok("Deleted");
        }
    }
}
