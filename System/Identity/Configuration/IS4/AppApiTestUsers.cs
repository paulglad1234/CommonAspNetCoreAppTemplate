namespace Template.Identity;

using Duende.IdentityServer.Test;

public static class AppApiTestUsers
{
    public static List<TestUser> ApiUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "root",
                Password = "password"
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "admin",
                Password = "password"
            }
        };
}