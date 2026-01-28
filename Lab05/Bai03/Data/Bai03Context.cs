using Bai03.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai03.Data
{
    public class Bai03Context : DbContext
    {
        public Bai03Context(DbContextOptions<Bai03Context> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubscription> CourseSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình cho bảng trung gian quan hệ Nhiều - Nhiều
            modelBuilder.Entity<CourseSubscription>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                // Cấu hình mối quan hệ với Student
                entity.HasOne(e => e.Student)
                      .WithMany(s => s.CourseSubscriptions)
                      .HasForeignKey(e => e.StudentId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Cấu hình mối quan hệ với Course
                entity.HasOne(e => e.Course)
                      .WithMany(c => c.CourseSubscriptions)
                      .HasForeignKey(e => e.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}