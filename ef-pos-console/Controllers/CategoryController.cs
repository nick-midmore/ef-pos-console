using ef_pos_console.Models;

namespace ef_pos_console.Controllers;
internal class CategoryController
{
    internal static void AddCategory(Category category)
    {
        using var db = new ProductContext();

        db.Add(category);

        db.SaveChanges();
    }
}
