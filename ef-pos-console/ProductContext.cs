using ef_pos_console.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_pos_console;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source = products.db");

}
