namespace Template.Identity.Configuration;

using Template.Db.Context;
using Template.Db.Context.Factories;
using Template.Settings;
using Microsoft.Extensions.DependencyInjection;

public static class DbConfiguration
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IDbSettings settings)
    {
        var dbOptionsDelegate = DbContextOptionsFactory.Configure(settings.ConnectionString);

        services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);

        return services;
    }

    public static IApplicationBuilder UseAppDbContext(this IApplicationBuilder app)
    {
        return app;
    }
}
