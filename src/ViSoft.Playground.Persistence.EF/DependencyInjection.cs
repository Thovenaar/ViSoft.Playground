using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViSoft.Playground.Domain.Repositories;

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

        services.AddScoped<IUserRepository, UserRepository>();

        //services.AddDbContextFactory<AppDbContext>(options =>
        //{
        //    options.UseSqlServer(connectionString);
        //});

        return services;
    }
}