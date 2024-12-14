using Spectre.Console;

namespace ef_pos_console;
static internal class UI
{
    static internal void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var product in products)
        {
            table.AddRow(product.Id.ToString(), product.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
    }
}
