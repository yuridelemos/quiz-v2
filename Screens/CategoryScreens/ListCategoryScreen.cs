using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;

namespace quiz_v2.Screens.CategoryScreens;

internal class ListCategoryScreen
{
    internal static void Load(QuizDataContext context)
    {
        Console.Clear();
        Console.WriteLine("Lista de categorias");
        Console.WriteLine("--------------");
        try
        {
            var categories = context.Categories
                .AsNoTracking()
                .ToList();
            categories.Select((category, index) => $"{index + 1} - {category.Name}")
                .ToList()
                .ForEach(Console.WriteLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível listar as categorias.");
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
        MenuCategoryScreen.Load(context);
        Console.ReadKey();
    }

    internal static void ListForEdit(QuizDataContext context)
    {
        try
        {
            var categories = context.Categories
                .AsNoTracking()
                .ToList();
            categories.Select((category) => $"{category.Id} - {category.Name}")
                .ToList()
                .ForEach(Console.WriteLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível listar as categorias.");
            Console.WriteLine(ex.Message);
        }
    }
}
