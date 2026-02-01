using Microsoft.EntityFrameworkCore;
using Bai01.Models;

namespace Bai01.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}