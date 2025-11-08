using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LubriTech.Persistence;

internal sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql("Host=localhost;Port=5432;Database=database;Username=postgres;Password=admin");
        return new AppDbContext(optionsBuilder.Options);
    }
}
