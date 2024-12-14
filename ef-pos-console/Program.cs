using ef_pos_console;
using Spectre.Console;

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
            ProductController.UpdateProduct();
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


enum MenuOption
{
    AddProduct,
    UpdateProduct,
    DeleteProduct,
    ViewProduct,
    ViewAllProducts,
    Quit
}