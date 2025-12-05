namespace UniversityManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int UniversityId { get; set; }

        public University University { get; set; }
        public ICollection<StudentLesson> StudentLessons { get; set; }
    }
}
