using LubriTech.Persistence.IntegrationTest.Fixtures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit.Abstractions;

namespace LubriTech.Persistence.IntegrationTest;

[Collection(nameof(DatabaseCollectionFixture))]
public abstract class TestBase(
    DatabaseFixture fixture, 
    ITestOutputHelper outputHelper) 
    : IAsyncLifetime
{
    protected readonly ITestOutputHelper testOutputHelper = outputHelper;
    protected readonly AppDbContext context = fixture.GetDbContext();
    public Task DisposeAsync() => context.DisposeAsync().AsTask();

    public async Task InitializeAsync()
    {
        testOutputHelper.WriteLine($"Connection string: {fixture.ConnectionString} ");
        await context.Database.MigrateAsync();
    }
    protected void ExecuteInATransaction(Action action)
    {
        IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
        strategy.Execute(() =>
        {
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            action();
            transaction.Rollback();
        });
    }
    protected Task ExecuteInATransactionAsync(Func<Task> action)
    {
        IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
        return strategy.ExecuteAsync(async () =>
        {
            await using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync();
            await action();
            return transaction.RollbackAsync();
        });
    }
}
