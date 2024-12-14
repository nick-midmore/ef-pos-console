using Spectre.Console;

namespace ef_pos_console;
internal class ProductService
{
    static internal Product GetProductOptionInput()
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
}
