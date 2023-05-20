using Microsoft.EntityFrameworkCore;
using ViSoft.Playground.Domain.Users;

namespace ViSoft.Playground.Application.Data;

public interface IAppDbContext
{
    DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}