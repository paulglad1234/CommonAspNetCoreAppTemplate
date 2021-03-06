using Template.Settings;

namespace Template.Api;

/// <summary>
/// 
/// </summary>
public static class Bootstrapper
{
    /// <summary>
    /// Add business layer services to the service collection
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <returns>Service collection</returns>
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services
            .AddSettings();

        return services;
    }
}
