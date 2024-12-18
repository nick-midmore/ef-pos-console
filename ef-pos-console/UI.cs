using ef_pos_console.Models;
using ef_pos_console.Services;
using Spectre.Console;

namespace ef_pos_console;
static internal class UI
{
    internal static void MainMenu()
    {
        var isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOption>()
            .Title("What would you like to do?")
            .AddChoices(
                MenuOption.AddProduct,
                MenuOption.UpdateProduct,
                MenuOption.DeleteProduct,
                MenuOption.ViewProduct,
                MenuOption.ViewAllProducts,
                MenuOption.AddCategory,
                MenuOption.DeleteCategory,
                MenuOption.UpdateCategory,
                MenuOption.ViewAllCategories,
                MenuOption.Quit
            ));

            switch (option)
            {
                case MenuOption.AddProduct:
                    ProductService.AddProduct();
                    break;
                case MenuOption.UpdateProduct:
                    ProductService.UpdateProduct();
                    break;
                case MenuOption.DeleteProduct:
                    ProductService.DeleteProduct();
                    break;
                case MenuOption.ViewProduct:
                    ProductService.GetProduct();
                    break;
                case MenuOption.ViewAllProducts:
                    ProductService.GetAllProducts();
                    break;
                case MenuOption.AddCategory:
                    CategoryService.AddCategory();
                    break;
                case MenuOption.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case MenuOption.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case MenuOption.ViewAllCategories:
                    CategoryService.GetCategories();
                    break;
                case MenuOption.Quit:
                    isRunning = false;
                    break;
                default:
                    break;
            }
        }
    }

    internal static void ShowProduct(Product product)
    {
        var panel = new Panel($@"Id: {product.ProductId}
Name: {product.Name}
Price: {product.Price}
Category: {product.Category.Name}");
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 1, 2, 1);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
    }

    internal static void ListProducts(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");
        table.AddColumn("Category");

        foreach (var product in products)
        {
            table.AddRow(
                product.ProductId.ToString(),
                product.Name,
                product.Price.ToString(),
                product.Category.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
    }

    internal static void ListCategories(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Product count");

        foreach (var category in categories)
        {
            table.AddRow(
                category.CategoryId.ToString(),
                category.Name,
                category.Products.Count.ToString());
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
    }
}
