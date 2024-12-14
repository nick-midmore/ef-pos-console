using Microsoft.EntityFrameworkCore;

namespace ef_pos_console;

internal class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source = products.db");

}
