using Bai03.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai03.Data
{
    public class Bai03Context : DbContext
    {
        public Bai03Context(DbContextOptions<Bai03Context> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}