namespace UniversityManagement.Models
{
    namespace UniversityManagement.Models
    {
        public class Lesson
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int UniversityId { get; set; }

            public University University { get; set; }
            public ICollection<StudentLesson> StudentLessons { get; set; }
        }
    }

}
