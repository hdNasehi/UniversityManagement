using UniversityManagement.Models.UniversityManagement.Models;

namespace UniversityManagement.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
