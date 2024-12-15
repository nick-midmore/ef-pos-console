using ef_pos_console.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_pos_console.Controllers;
internal class CategoryController
{
    internal static void AddCategory(Category category)
    {
        using var db = new ProductContext();

        db.Add(category);

        db.SaveChanges();
    }

    internal static List<Category> GetCategories()
    {
        using var db = new ProductContext();

        return db.Categories
            .Include(x => x.Products)
            .ToList();
    }
}
