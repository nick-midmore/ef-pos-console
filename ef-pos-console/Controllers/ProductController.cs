using ef_pos_console.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace ef_pos_console.Controllers;

internal class ProductController
{
    internal static void AddProduct(Product product)
    {
        using var db = new ProductContext();
        db.Add(product);

        db.SaveChanges();
    }

    internal static void DeleteProduct(Product product)
    {
        using var db = new ProductContext();
        db.Remove(product);

        db.SaveChanges();
    }

    internal static void UpdateProduct(Product product)
    {
        using var db = new ProductContext();
        db.Update(product);

        db.SaveChanges();
    }

    internal static List<Product> GetProducts()
    {
        using var db = new ProductContext();

        return db.Products.ToList();
    }

    internal static Product GetProductById(int id)
    {
        using var db = new ProductContext();

        return  db.Products
            .Include(x => x.Category)
            .SingleOrDefault(x => x.ProductId == id);
    }
}
