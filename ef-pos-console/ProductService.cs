using Spectre.Console;

namespace ef_pos_console;
internal class ProductService
{
    static private Product GetProductOptionInput()
    {
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Product")
            .AddChoices(
                ProductController.GetProducts()
                .Select(x => x.Name)
                .ToArray()));
        var product = ProductController.GetProductById(ProductController.GetProducts()
            .Single(x => x.Name == option).Id);

        return product;
    }

    static internal void AddProduct()
    {
        var name = AnsiConsole.Ask<string>("Product name:");
        ProductController.AddProduct(name);
    }

    static internal void UpdateProduct()
    {
        var product = GetProductOptionInput();
        product.Name = AnsiConsole.Ask<string>("New product name:");
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
