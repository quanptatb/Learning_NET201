using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bai02.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai02.Data
{
    public class Bai02bContext : DbContext
    {
        public Bai02bContext(DbContextOptions<Bai02bContext> options) : base(options) { }
        public DbSet<NhanVienB> NhanViens { get; set; }
        public DbSet<ThanNhanB> ThanNhans { get; set; }
    }
}