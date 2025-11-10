using LubriTech.Persistence.IntegrationTest.Fixtures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit.Abstractions;

namespace LubriTech.Persistence.IntegrationTest;

public abstract class TestBase(
    DatabaseFixture fixture, 
    ITestOutputHelper outputHelper) 
    : IAsyncLifetime
{
    protected readonly ITestOutputHelper TestOutputHelper = outputHelper;
    protected readonly AppDbContext Context = fixture.Context;
    public virtual Task DisposeAsync() => Context.DisposeAsync().AsTask();
    public virtual Task InitializeAsync()
    {
        TestOutputHelper.WriteLine($"Connection string: {fixture.ConnectionString}");
        return Task.CompletedTask;
    }
    protected void ExecuteInATransaction(Action action)
    {
        IExecutionStrategy strategy = Context.Database.CreateExecutionStrategy();
        strategy.Execute(action,(operation) =>
        {
            using IDbContextTransaction transaction = Context.Database.BeginTransaction();
            operation();
            transaction.Rollback();
        });
    }
    protected Task ExecuteInATransactionAsync(Func<Task> action)
    {
        IExecutionStrategy strategy = Context.Database.CreateExecutionStrategy();
        return strategy.ExecuteAsync(action, async (operation) => 
        {
            await using IDbContextTransaction transaction = await Context.Database.BeginTransactionAsync();
            await operation();
            await transaction.RollbackAsync();
        });
    }
}
