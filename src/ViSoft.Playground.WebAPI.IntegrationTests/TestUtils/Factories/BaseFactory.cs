using System.Data.Common;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respawn;
using ViSoft.Playground.Persistence.EF;

namespace ViSoft.Playground.WebAPI.IntegrationTests.TestUtils.Factories;

public abstract class BaseFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    public HttpClient HttpClient { get; private set; } = default;
    private DbConnection _dbConnection = default!;
    private Respawner _respawner = default!;
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

    public async Task ResetDatabaseAsync()
    {
        await _respawner.ResetAsync(_dbConnection);
        await SeedData();
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        _dbConnection = new SqlConnection(BuildInsecureConnectionString(_dbContainer));

        var dbContext = GetAppDbContext();
        await dbContext.Database.EnsureCreatedAsync();

        await SeedData();

        HttpClient = CreateClient();

        await InitializeRespawner();
    }

    private async Task InitializeRespawner()
    {
        await _dbConnection.OpenAsync();
        _respawner = await Respawner.CreateAsync(_dbConnection, new RespawnerOptions
        {
            DbAdapter = DbAdapter.SqlServer
        });
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