using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Data;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly UniversityDbContext _context;

        public EnrollmentController(UniversityDbContext context)
        {
            _context = context;
        }

        // POST: api/enrollment/enroll
        [HttpPost("enroll")]
        public async Task<IActionResult> Enroll([FromBody] EnrollRequest request)
        {
            // 1) وجود دانشجو
            var studentExists = await _context.Students.AnyAsync(s => s.Id == request.StudentId);
            if (!studentExists)
                return NotFound($"StudentId {request.StudentId} not found.");

            // 2) وجود درس‌ها
            var lessons = await _context.Lessons
                .Where(l => request.LessonIds.Contains(l.Id))
                .ToListAsync();

            if (lessons.Count != request.LessonIds.Count)
                return BadRequest("One or more LessonIds are invalid.");

            // 3) جلوگیری از انتخاب تکراری
            var alreadySelected = await _context.StudentLessons
                .Where(sl => sl.StudentId == request.StudentId && request.LessonIds.Contains(sl.LessonId))
                .Select(sl => sl.LessonId)
                .ToListAsync();

            var newLessonIds = request.LessonIds.Except(alreadySelected).ToList();

            foreach (var lessonId in newLessonIds)
            {
                _context.StudentLessons.Add(new StudentLesson
                {
                    StudentId = request.StudentId,
                    LessonId = lessonId
                });
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                StudentId = request.StudentId,
                AddedLessonIds = newLessonIds,
                AlreadySelectedLessonIds = alreadySelected
            });
        }

        // GET: api/enrollment/student/1
        [HttpGet("student/{studentId:int}")]
        public async Task<IActionResult> GetStudentEnrollments(int studentId)
        {
            var student = await _context.Students
                .Include(s => s.StudentLessons)
                    .ThenInclude(sl => sl.Lesson)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null) return NotFound("Student not found.");

            var lessons = student.StudentLessons.Select(sl => new
            {
                sl.LessonId,
                sl.Lesson.Name,
                Unit = (int)sl.Lesson.Unit
            }).ToList();

            var totalUnits = lessons.Sum(x => x.Unit);

            return Ok(new
            {
                student.Id,
                student.FullName,
                TotalUnits = totalUnits,
                Lessons = lessons
            });
        }
    }

    public class EnrollRequest
    {
        public int StudentId { get; set; }
        public List<int> LessonIds { get; set; } = new();
    }
}
