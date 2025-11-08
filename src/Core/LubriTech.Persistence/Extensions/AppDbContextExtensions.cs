using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LubriTech.Persistence.Extensions;

public static class AppDbContextExtensions
{
    private static readonly string _connectionStringName = "DefaultConnection";

    internal static IServiceCollection AddDBProvider(this IServiceCollection services)
        => services.AddDbContext<AppDbContext>((sp, options) =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            string? cs = configuration.GetConnectionString(_connectionStringName);
            ArgumentException.ThrowIfNullOrEmpty(cs, _connectionStringName);
            options.UseNpgsql(cs);
        });

    internal static IServiceCollection AddRepositories(this IServiceCollection services) => services;
    public static IServiceCollection AddDataAccessProvider(this IServiceCollection services)
        => services.AddDBProvider();
}
