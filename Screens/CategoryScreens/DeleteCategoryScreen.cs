using quiz_v2.Data;

namespace quiz_v2.Screens.CategoryScreens;

internal class DeleteCategoryScreen
{
    internal static void Load()
    {
        Console.WriteLine("-----DELETAR CATEGORIA-----");
        Console.WriteLine("(1) - Deletar categoria");
        Console.WriteLine("(0) - Voltar");
        Console.Write("-------------: ");
        var option = short.Parse(Console.ReadLine());
        Console.WriteLine("OBS: Ao deletar uma categoria, todas as questões e respostas presentes nela também serão deletadas.");
        if (option == 0)
            MenuCategoryScreen.Load();
        Console.Clear();
        Console.WriteLine("Deletar categoria");
        Console.WriteLine("-------------");
        ListCategoryScreen.ListForEdit();
        Console.WriteLine("-------------");
        Console.Write("ID: ");
        var id = short.Parse(Console.ReadLine());
        Delete(id);
    }


    private static void Delete(short id)
    {
        try
        {
            using var context = new QuizDataContext();
            var category = context.Categories
                .FirstOrDefault(x => x.Id == id);
            context.Categories.Remove(category);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível deletar a categoria.");
            Console.WriteLine(ex.Message);
        }
    }
}
