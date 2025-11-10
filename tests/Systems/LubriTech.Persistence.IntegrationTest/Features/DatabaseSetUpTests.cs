using LubriTech.Persistence.IntegrationTest.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace LubriTech.Persistence.IntegrationTest.Features;

[Collection(nameof(DatabaseCollectionFixture))]
public class DatabaseSetUpTests(
    DatabaseFixture fixture,
    ITestOutputHelper outputHelper)
    : TestBase(fixture, outputHelper)
{
    // {ThingUnderTest}_Should_{ExpectedBehavior}_When_{StateUnderTest}
    [Fact]
    public async Task Database_Should_BeReachable()
    {
        bool canConnect = await Context.Database.CanConnectAsync();
        Assert.True(canConnect);
    }

    [Fact]
    public async Task Migrations_Should_BeApplied_After_Initialization()
    {
        IEnumerable<string> pendingMigrations = await Context.Database.GetPendingMigrationsAsync();
        Assert.Empty(pendingMigrations);
    }

    [Fact]
    public void Provider_Should_BePostgreSql()
    {
        string providerName = Context.Database.ProviderName ?? string.Empty;
        TestOutputHelper.WriteLine($"Provider Name: {providerName} ");
        Assert.Equal("Npgsql.EntityFrameworkCore.PostgreSQL", providerName);
    }

    [Fact]
    public async Task SeededData_Should_Exist_After_Initialization()
    {
        int categoriesCount = await Context.Categories.CountAsync();
        TestOutputHelper.WriteLine($"Categories count: {categoriesCount} ");
        Assert.True(categoriesCount > 0);
    }
}