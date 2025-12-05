using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Student
            {
                FullName="Mahan",
                Id=1
            })
            .ToArray();
        }
    }
}
