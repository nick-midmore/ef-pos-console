using ef_pos_console.Controllers;
using ef_pos_console.Models;
using Spectre.Console;

namespace ef_pos_console;
internal class ProductService
{
    static private Product GetProductOptionInput()
    {
        var products = ProductController.GetProducts();
        var productGroups = products.GroupBy(p => p.Name).ToList();

        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Product")
            .AddChoices(productGroups.Select(g => g.Key).ToArray()));

        // Check for duplicates
        var selectedGroup = productGroups.First(g => g.Key == option);

        if (selectedGroup.Count() > 1)
        {
            AnsiConsole.Markup("[red]Multiple products found with the same name.[/]\n");
            var selectedProduct = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Specific Product")
                .AddChoices(selectedGroup.Select(p => $"ID: {p.ProductId}, Name: {p.Name}, Price: {p.Price}").ToArray()));

            int selectedProductId = int.Parse(selectedProduct.Split(',')[0].Split(':')[1].Trim());
            return products.First(p => p.ProductId == selectedProductId);
        }
        else
        {
            return selectedGroup.First();
        }
    }


    static internal void AddProduct()
    {
        var product = new Product();
        product.Name = AnsiConsole.Ask<string>("Product name:");
        product.Price = AnsiConsole.Ask<decimal>("Product price:");
        ProductController.AddProduct(product);
    }

    static internal void UpdateProduct()
    {
        var product = GetProductOptionInput();

        product.Name = AnsiConsole.Confirm("Update product name?")
            ? AnsiConsole.Ask<string>("Enter new product name")
            : product.Name;
        product.Price = AnsiConsole.Confirm("Update product price?")
            ? AnsiConsole.Ask<decimal>("Enter new price")
            : product.Price;

        ProductController.UpdateProduct(product);
    }

    static internal void DeleteProduct()
    {
        var product = GetProductOptionInput();
        ProductController.DeleteProduct(product);
    }

    static internal void GetAllProducts()
    {
        var products = ProductController.GetProducts();
        UI.ShowProductTable(products);
    }

    static internal void GetProduct()
    {
        var product = GetProductOptionInput();
        UI.ShowProduct(product);
    }
}
