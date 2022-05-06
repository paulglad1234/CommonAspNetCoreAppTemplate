using Template.Api.Middleware;

namespace Template.Api.Configuration;

/// <summary>
/// Middleware configuration class
/// </summary>
public static class MiddlewareConfiguration
{
    /// <summary>
    /// Enables all app middlewares
    /// </summary>
    /// <param name="app">Application</param>
    public static IApplicationBuilder UseAppMiddlwares(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionsMiddleware>();
    }
}
