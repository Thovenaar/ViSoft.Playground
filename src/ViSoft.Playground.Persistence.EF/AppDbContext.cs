using Microsoft.EntityFrameworkCore;
using ViSoft.Playground.Persistence.EF.Models;

namespace ViSoft.Playground.Persistence.EF
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User.BuildModel(modelBuilder);
        }
    }
}
