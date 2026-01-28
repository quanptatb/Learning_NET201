using Bai02.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai02.Data
{
    public class Bai02aContext : DbContext
    {
        public Bai02aContext(DbContextOptions<Bai02aContext> options) : base(options) { }

        public DbSet<NhanVienA> NhanViens { get; set; }
        public DbSet<ThanNhanA> ThanNhans { get; set; }
    }
}