using LubriTech.Persistence.IntegrationTest.Initializers;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace LubriTech.Persistence.IntegrationTest.Fixtures;

public sealed class DatabaseFixture : IAsyncLifetime
{
    private PostgreSqlContainer? _container;
    public AppDbContext Context { get; private set; } = null!;
    public string ConnectionString =>
        _container?.GetConnectionString() ?? 
        throw new InvalidOperationException("Container is not started yet.");
    public async Task InitializeAsync()
    {
        _container = new PostgreSqlBuilder().Build();
        await _container.StartAsync();
        Context = GetDbContext();
        await Context.Database.MigrateAsync();
    }
    public Task DisposeAsync() => _container!.DisposeAsync().AsTask();
    private AppDbContext GetDbContext()
    {
        DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql($"{ConnectionString};Include Error Detail=true")
            .UseAsyncSeeding((context, _, _) => DataInitializer.SeedDataAsync(context))
            .Options;
        AppDbContext context = new(options);
        return context;
    }
}
