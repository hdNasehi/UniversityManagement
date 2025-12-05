namespace UniversityManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int UniversityId { get; set; }

        public University University { get; set; }
    }
}
