//using UniversityManagement.Enums;

//namespace UniversityManagement.Models
//{
//    namespace UniversityManagement.Models
//    {
//        public class Lesson
//        {
//            public int Id { get; set; }
//            public string Name { get; set; }
//            public int UniversityId { get; set; }

//            public University University { get; set; }
//            public ICollection<StudentLesson> StudentLessons { get; set; }
//        }
//    }

//}
using System.Collections.Generic;
using UniversityManagement.Enums;

namespace UniversityManagement.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UniversityId { get; set; }
        public University University { get; set; }

        // 2 / 4 / 6 units
        public CourseUnit Unit { get; set; }

        public ICollection<StudentLesson> StudentLessons { get; set; } = new List<StudentLesson>();
    }
}
