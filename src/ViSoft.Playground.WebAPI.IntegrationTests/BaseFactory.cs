using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using ViSoft.Playground.Persistence.EF;

namespace ViSoft.Playground.WebAPI.IntegrationTests;

public abstract class BaseFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlTestcontainer _dbContainer =
        new TestcontainersBuilder<MsSqlTestcontainer>()
            .WithEnvironment("ACCEPT_EULA", "Y")
            .WithDatabase(
                new MsSqlTestcontainerConfiguration
                {
                    Password = "UltraSecret92120!!"
                })
            .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseSetting("ConnectionStrings:DefaultConnection", BuildInsecureConnectionString(_dbContainer));
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();

        var dbContext = GetAppDbContext();
        await dbContext.Database.EnsureCreatedAsync();

        await SeedData();
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.DisposeAsync();
    }

    public abstract Task SeedData();

    internal AppDbContext GetAppDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(BuildInsecureConnectionString(_dbContainer));
        return new AppDbContext(optionsBuilder.Options);
    }

    private static string BuildInsecureConnectionString(MsSqlTestcontainer container) =>
        $"{container.ConnectionString};TrustServerCertificate=yes;";

}