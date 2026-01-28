using Bai01.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai01.Data
{
    public class Bai01cContext : DbContext
    {
        public Bai01cContext(DbContextOptions<Bai01cContext> options) : base(options) { }

        public DbSet<StudentC> Students { get; set; }
        public DbSet<StudentDetailC> StudentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Config Student
            modelBuilder.Entity<StudentC>(entity =>
            {
                entity.ToTable("students");
                entity.HasKey(e => e.StudentId);
                entity.Property(e => e.StudentId).HasColumnName("student_id").HasColumnType("INT");
                entity.Property(e => e.FirstName).HasColumnName("first_name").HasColumnType("VARCHAR").HasMaxLength(50);
                entity.Property(e => e.LastName).HasColumnName("last_name").HasColumnType("VARCHAR").HasMaxLength(50);
            });

            // Config StudentDetail
            modelBuilder.Entity<StudentDetailC>(entity =>
            {
                entity.ToTable("student_details");
                entity.HasKey(e => e.StudentId); // PK
                entity.Property(e => e.StudentId).HasColumnName("student_id").HasColumnType("INT");
                entity.Property(e => e.Email).HasColumnName("email").HasColumnType("VARCHAR").HasMaxLength(100);
                entity.Property(e => e.DateBirth).HasColumnName("date_birth").HasColumnType("DATE");

                // Config One-to-One
                entity.HasOne(d => d.Student)
                      .WithOne(p => p.StudentDetail)
                      .HasForeignKey<StudentDetailC>(d => d.StudentId); // Shared PK mapping
            });
        }
    }
}