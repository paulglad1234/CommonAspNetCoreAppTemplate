using Microsoft.Extensions.DependencyInjection;

namespace Template.Common.Helpers;

public static class AutoMapperRegisterHelper
{
    public static void Register(IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(s => s.FullName != null && s.FullName.StartsWith("Template."));

        services.AddAutoMapper(assemblies);
    }
}
