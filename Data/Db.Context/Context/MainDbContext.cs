using Microsoft.EntityFrameworkCore;

namespace Db.Context;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
}
