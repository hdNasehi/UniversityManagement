using System.Collections.Generic;

namespace UniversityManagement.Models
{
    public class University
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Student> Students { get; set; } = new List<Student>();

        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
