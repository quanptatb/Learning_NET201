using Bai01.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai01.Data
{
    public class Bai01bContext : DbContext
    {
        public Bai01bContext(DbContextOptions<Bai01bContext> options) : base(options) { }

        public DbSet<StudentB> Students { get; set; }
        public DbSet<StudentDetailB> StudentDetails { get; set; }
    }
}