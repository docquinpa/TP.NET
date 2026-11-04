using FTELMarket.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FTELMarket.Infrastructure;

public class FtelMarketDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    public FtelMarketDbContext(DbContextOptions<FtelMarketDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FtelMarketDbContext).Assembly);
    }
}
