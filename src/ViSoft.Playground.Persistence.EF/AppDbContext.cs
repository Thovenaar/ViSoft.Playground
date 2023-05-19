using Microsoft.EntityFrameworkCore;
using ViSoft.Playground.Application.Data;
using ViSoft.Playground.Domain.Users;

namespace ViSoft.Playground.Persistence.EF
{
    internal class AppDbContext : DbContext, IAppDbContext, IUnitOfWork
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
