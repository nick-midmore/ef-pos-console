
using Spectre.Console;

namespace ef_pos_console;

internal class ProductController
{
    internal static void AddProduct()
    {
        var name = AnsiConsole.Ask<string>("Product name:");
        using var db = new ProductContext();
        db.Add(new Product { Name = name });

        db.SaveChanges();
    }

    internal static void DeleteProduct()
    {
        throw new NotImplementedException();
    }

    internal static void UpdateProduct()
    {
        throw new NotImplementedException();
    }

    internal static List<Product> GetProducts()
    {
        using var db = new ProductContext();

        var products = db.Products.ToList();

        return products;
    }

    internal static Product GetProductById(int id)
    {
        using var db = new ProductContext();

        var product = db.Products.SingleOrDefault(x => x.Id == id);

        return product;
    }
}
