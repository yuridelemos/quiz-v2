using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;
using quiz_v2.Models;

namespace quiz_v2.Screens.CategoryScreens;

public class CreateCategoryScreen
{
    public static void Create()
    {
        using var context = new QuizDataContext();
        Console.WriteLine("-----CRIAÇÃO DE CATEGORIA-----");
        Console.WriteLine("(1) - Criar categoria");
        Console.WriteLine("(0) - Voltar");
        var option = int.Parse(Console.ReadLine());
        if (option == 0)
            MenuCategoryScreen.Load();
        Console.Clear();
        Console.WriteLine("Nova categoria");
        Console.WriteLine("-------------");
        Console.Write("Nome: ");
        var matter = Console.ReadLine();

        CheckDuplicity(context, matter);

        try
        {
            context.Categories
            .Add(new Category
            {
                Name = matter,
                Slug = matter.ToLower()
            });
            context.SaveChanges();
            Console.WriteLine("Categoria cadastrada com sucesso!");
            Create();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar a categoria");
            Console.WriteLine(ex.Message);
        }
    }

    private static void CheckDuplicity(QuizDataContext context, string matter)
    {
        var categories = context.Categories
                        .AsNoTracking()
                        .ToList();
        foreach (var category in categories)
        {
            if (category == null || category.Name == matter)
            {
                Console.WriteLine("Não foi possível efetuar o cadastrar, matéria já cadastrada.");
                Console.WriteLine("Presione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Create();
            }
        }
    }
}
