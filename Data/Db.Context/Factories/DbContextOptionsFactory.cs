using Microsoft.EntityFrameworkCore;

namespace Template.Db.Context.Factories;

public class DbContextOptionsFactory
{
    public static DbContextOptions<MainDbContext> Create(string connectionString)
    {
        var builder = new DbContextOptionsBuilder<MainDbContext>();
        Configure(connectionString).Invoke(builder);
        return builder.Options;
    }

    public static Action<DbContextOptionsBuilder> Configure(string connectionString)
    {
        return (builder) => builder.UseSqlServer(connectionString);
    }
}
