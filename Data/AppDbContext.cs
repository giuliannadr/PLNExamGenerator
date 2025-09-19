using Microsoft.EntityFrameworkCore;
using PNLExamGenerator.Models;

namespace PNLExamGenerator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
