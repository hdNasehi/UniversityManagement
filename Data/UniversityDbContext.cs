using Microsoft.EntityFrameworkCore;
using UniversityManagement.Models;



namespace UniversityManagement.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
            : base(options) { }

        public DbSet<University> Universities { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentLesson>()
                .HasKey(sl => new { sl.StudentId, sl.LessonId });

            modelBuilder.Entity<StudentLesson>()
                .HasOne(sl => sl.Student)
                .WithMany(s => s.StudentLessons)
                .HasForeignKey(sl => sl.StudentId)
                .OnDelete(DeleteBehavior.Restrict); // <- prevent cascade

            modelBuilder.Entity<StudentLesson>()
                .HasOne(sl => sl.Lesson)
                .WithMany(l => l.StudentLessons)
                .HasForeignKey(sl => sl.LessonId)
                .OnDelete(DeleteBehavior.Restrict); // <- prevent cascade
        }

    }
}
