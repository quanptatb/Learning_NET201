using Bai01.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai01.Data
{
    public class Bai01aContext : DbContext
    {
        public Bai01aContext(DbContextOptions<Bai01aContext> options) : base(options) { }

        public DbSet<StudentA> Students { get; set; }
        public DbSet<StudentDetailA> StudentDetails { get; set; }
    }
}