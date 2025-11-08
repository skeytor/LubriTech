using LubriTech.Persistence.IntegrationTest.Initializers;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace LubriTech.Persistence.IntegrationTest.Fixtures;

public sealed class DatabaseFixture : IAsyncLifetime
{
    private PostgreSqlContainer? _container;
    public string ConnectionString =>
        _container?.GetConnectionString() ?? 
        throw new InvalidOperationException("Container is not started.");
    public Task InitializeAsync()
    {
        _container = new PostgreSqlBuilder().Build();
        return _container.StartAsync();
    }
    public AppDbContext GetDbContext()
    {
        DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(ConnectionString)
            .UseAsyncSeeding((context, _, _) => DataInitializer.SeedDataAsync(context))
            .Options;
        AppDbContext context = new(options);
        return context;
    }
    public Task DisposeAsync() => _container!.DisposeAsync().AsTask();
}
