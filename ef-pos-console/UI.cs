using ef_pos_console.Models;
using Spectre.Console;

namespace ef_pos_console;
static internal class UI
{
    internal static void MainMenu()
    {
        var isRunning = true;

        while (isRunning)
        {
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOption>()
            .Title("What would you like to do?")
            .AddChoices(
                MenuOption.AddProduct,
                MenuOption.UpdateProduct,
                MenuOption.DeleteProduct,
                MenuOption.ViewProduct,
                MenuOption.ViewAllProducts,
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
            Price: {product.Price}");
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 1, 2, 1);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
    }

    internal static void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");

        foreach (var product in products)
        {
            table.AddRow(
                product.ProductId.ToString(), 
                product.Name, 
                product.Price.ToString());
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
    }
}
