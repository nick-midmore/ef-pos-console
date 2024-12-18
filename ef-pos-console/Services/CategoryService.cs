using ef_pos_console.Controllers;
using ef_pos_console.Models;
using Spectre.Console;

namespace ef_pos_console.Services;
internal class CategoryService
{
    static internal Category GetCategoryOptionInput()
    {
        var categories = CategoryController.GetCategories();
        var categoryGroups = categories.GroupBy(p => p.Name).ToList();

        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose category")
            .AddChoices(categoryGroups.Select(g => g.Key).ToArray()));

        var selectedGroup = categoryGroups.First(g => g.Key == option);

        if (selectedGroup.Count() > 1)
        {
            AnsiConsole.Markup("[red]Multiple categories found with the same name.[/]\n");
            var selectedcategory = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Specific category")
                .AddChoices(selectedGroup.Select(p => $"ID: {p.CategoryId}, Name: {p.Name}").ToArray()));

            int selectedcategoryId = int.Parse(selectedcategory.Split(',')[0].Split(':')[1].Trim());
            return categories.First(p => p.CategoryId == selectedcategoryId);
        }
        else
        {
            return selectedGroup.First();
        }
    }

    internal static void AddCategory()
    {
        var category = new Category();

        category.Name = AnsiConsole.Ask<string>("Category name:");

        CategoryController.AddCategory(category);
    }

    internal static void GetCategories()
    {
        UI.ListCategories(CategoryController.GetCategories());
    }

    internal static void UpdateCategory()
    {
        var category = GetCategoryOptionInput();

        category.Name = AnsiConsole.Confirm("Update category name?")
            ? AnsiConsole.Ask<string>("Enter new category name:")
            : category.Name;


        CategoryController.UpdateCategory(category);
    }

    internal static void DeleteCategory()
    {
        CategoryController.DeleteCategory(GetCategoryOptionInput());
    }
}
