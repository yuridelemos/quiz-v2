using quiz_v2.Data;
using quiz_v2.Models;

namespace quiz_v2.Screens.CategoryScreens;

internal class UpdateCategoryScreen
{
    public static void Load()
    {
        using var context = new QuizDataContext();
        System.Console.WriteLine("-----ATUALIZAR CATEGORIA-----");
        System.Console.WriteLine("(1) - Atualizar categoria");
        System.Console.WriteLine("(0) - Voltar");
        var option = int.Parse(Console.ReadLine());
        if (option == 0)
            MenuCategoryScreen.Load();
        Console.Clear();
        Console.WriteLine("Atualizar categoria");
        Console.WriteLine("-------------");

        Console.Write("ID: ");
        var id = int.Parse(Console.ReadLine());
        Console.Write("Escreva a nova categoria: ");
        var body = Console.ReadLine();

        var category = context
            .Categories
            .FirstOrDefault(x => x.Id == id);

        category.Name = body;

        context
            .Categories
            .Update(category);
        Console.ReadKey();
        context.SaveChanges();
        //Terminar colocando no try catch
        MenuCategoryScreen.Load();
    }

    public static void Update(Question question)
    {
        try
        {
            Console.WriteLine("Categoria atualizada com sucesso!");
            System.Console.WriteLine("Você deseja apagar todas as perguntas dessa categoria?");
            // atualizar as respostas
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a categoria");
            Console.WriteLine(ex.Message);
        }
    }
}
