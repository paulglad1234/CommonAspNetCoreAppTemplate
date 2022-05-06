using Microsoft.EntityFrameworkCore;

namespace Template.Db.Context;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
}
