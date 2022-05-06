namespace Template.Identity;

using Duende.IdentityServer.Models;
using Template.Common.Security;

public static class AppApiScopes
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AppScopes.Common, "Common scope")
        };
}