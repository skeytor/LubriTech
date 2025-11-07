using LubriTech.Persistence.IntegrationTest.Fixtures;
using Xunit.Abstractions;

namespace LubriTech.Persistence.IntegrationTest.Features;

public class DatabaseTests(
    DatabaseFixture fixture,
    ITestOutputHelper outputHelper)
    : TestBase(fixture, outputHelper)
{
    // {ThingUnderTest}_Should_{ExpectedBehavior}_When_{StateUnderTest}
    [Fact]
    public async Task Database_Should_BeReachable()
    {
        bool canConnect = await context.Database.CanConnectAsync();
        Assert.True(canConnect);
    }
}
