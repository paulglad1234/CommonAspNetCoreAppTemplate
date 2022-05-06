using Db.Context;
using Db.Context.Factories;
using Db.Context.Setup;
using Settings;

namespace Api.Configuration;

/// <summary>
/// Database configuration class
/// </summary>
public static class DbConfiguration
{
    /// <summary>
    /// Add DB context factory to the service colection
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="settings">App settings</param>
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IApiSettings settings)
    {
        var dbOptionsDelegate = DbContextOptionsFactory.Configure(settings.Db.ConnectionString);

        return services.AddDbContextFactory<MainDbContext>(dbOptionsDelegate, ServiceLifetime.Singleton);
    }

    /// <summary>
    /// Use database in the app
    /// </summary>
    /// <param name="app">Application</param>
    public static IApplicationBuilder UseAppDbContext(this WebApplication app)
    {
        DbInit.Execute(app.Services);
        DbSeed.Execute(app.Services);

        return app;
    }
}
