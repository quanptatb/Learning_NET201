using Bai04.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai04.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // Seed data (tạo dữ liệu mẫu để test)
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Nguyen Van A" },
                new Student { StudentId = 2, Name = "Tran Thi B" }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Title = "C# Programming" },
                new Course { CourseId = 2, Title = "Database SQL" }
            );
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 1 },
                new Enrollment { EnrollmentId = 2, StudentId = 1, CourseId = 2 },
                new Enrollment { EnrollmentId = 3, StudentId = 2, CourseId = 1 }
            );
        }
    }
}