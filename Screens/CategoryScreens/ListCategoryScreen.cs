using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;

namespace quiz_v2.Screens.CategoryScreens;

public class ListCategoryScreen
{
    public static void List()
    {
        Console.Clear();
        Console.WriteLine("Lista de categorias");
        Console.WriteLine("--------------");
        using var context = new QuizDataContext();
        var categories = context.Categories
            .AsNoTracking()
            .ToList();
        categories.Select((category, index) => $"{index + 1} - {category.Name}")
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        System.Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
        Console.ReadKey();
    }
}
