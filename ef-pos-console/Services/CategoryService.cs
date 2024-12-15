using ef_pos_console.Controllers;
using ef_pos_console.Models;
using Spectre.Console;

namespace ef_pos_console.Services;
internal class CategoryService
{
    internal static void AddCategory()
    {
        var category = new Category();

        category.Name = AnsiConsole.Ask<string>("Category name:");

        CategoryController.AddCategory(category);
    }
}
