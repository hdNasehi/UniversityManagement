namespace UniversityManagement.Controllers
{
    public class EnrollRequest
    {
        public int StudentId { get; set; }
        public List<int> LessonIds { get; set; } = new();
    }
}
