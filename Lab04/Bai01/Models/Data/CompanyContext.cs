using Bai01.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai01.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        public DbSet<Information> Information { get; set; }
    }
}