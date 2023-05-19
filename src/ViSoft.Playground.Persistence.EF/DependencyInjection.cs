using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViSoft.Playground.Application.Data;
using ViSoft.Playground.Domain.Users;
using ViSoft.Playground.Persistence.EF.Users;

namespace ViSoft.Playground.Persistence.EF;

public static class DependencyInjection
{
    public static IServiceCollection RegisterPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Expected a connection string setting: `ConnectionStrings:DefaultConnection`");
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AppDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}