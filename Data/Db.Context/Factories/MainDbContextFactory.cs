using Microsoft.EntityFrameworkCore;

namespace Db.Context.Factories;

public class MainDbContextFactory
{
    private readonly DbContextOptions<MainDbContext> options;

    public MainDbContextFactory(DbContextOptions<MainDbContext> options)
    {
        this.options = options;
    }

    public MainDbContext CreateDbContext()
    {
        return new MainDbContext(options);
    }
}
