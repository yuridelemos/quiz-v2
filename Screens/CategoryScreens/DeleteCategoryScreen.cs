using quiz_v2.Data;

namespace quiz_v2.Screens.CategoryScreens;

internal class DeleteCategoryScreen
{
    internal static void Load()
    {
        Console.WriteLine("-----DELETAR CATEGORIA-----");
        Console.WriteLine("(1) - Deletar categoria");
        Console.WriteLine("(0) - Voltar");
        var option = int.Parse(Console.ReadLine());
        if (option == 0)
            MenuCategoryScreen.Load();
        // Implementar uma opção de 0, 1 ou outra escolha para substituir esse IF simples
        Console.Clear();
        Console.WriteLine("Deletar categoria");
        Console.WriteLine("-------------");
        ListCategoryScreen.ListForEdit();
        Console.WriteLine("-------------");
        Console.Write("ID: ");
        var id = int.Parse(Console.ReadLine());
        Delete(id);
    }


    private static void Delete(int id)
    {
        using var context = new QuizDataContext();
        var category = context.Categories
            .FirstOrDefault(x => x.Id == id);
        context.Categories.Remove(category);
    }
}
