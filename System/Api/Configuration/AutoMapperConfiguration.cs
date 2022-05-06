namespace Template.Api.Configuration;

using Template.Common.Helpers;

public static class AutoMapperConfiguration
{
    public static IServiceCollection AddAppAutoMapper(this IServiceCollection services)
    {
        AutoMapperRegisterHelper.Register(services);

        return services;
    }
}