using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;
using quiz_v2.Screens.QuestionScreens;
using System.Globalization;
using System.Text;

namespace quiz_v2.Screens.CategoryScreens;

internal class UpdateCategoryScreen
{
    public static void Load()
    {
        Console.WriteLine("-----ATUALIZAR CATEGORIA-----");
        Console.WriteLine("(1) - Atualizar categoria");
        Console.WriteLine("(0) - Voltar");
        var option = int.Parse(Console.ReadLine());
        if (option == 0)
            MenuCategoryScreen.Load();
        Console.Clear();
        Console.WriteLine("Atualizar categoria");
        Console.WriteLine("-------------");
        ListCategoryScreen.ListUpdateScreen();
        Console.WriteLine("-------------");
        Console.Write("ID: ");
        var id = int.Parse(Console.ReadLine());
        Console.Write("Escreva a nova categoria: ");
        var body = Console.ReadLine();

        Update(id, body);
    }

    private static void Update(int id, string body)
    {
        using var context = new QuizDataContext();
        try
        {
            var category = context
                .Categories
                .Include(x => x.Questions)
                .FirstOrDefault(x => x.Id == id);

            category.Name = body;
            category.Slug = RemoveAccent(body);

            context
                .Categories
                .Update(category);
            context.SaveChanges();

            Console.WriteLine("Categoria atualizada com sucesso!");
            Console.WriteLine("Você deseja apagar todas as perguntas dessa categoria?");
            Console.WriteLine("(1) - Sim, desejo apagar todas as perguntas.");
            Console.WriteLine("(0) - Não, desejo voltar ao menu.");
            var option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                    MenuCategoryScreen.Load();
                    break;
                case 1:
                    var questions = context.Questions
                        .Where(x => x.Category.Id == category.Id)
                        .ToList();
                    foreach (var question in questions)
                        context.Questions.Remove(question);
                    context.SaveChanges();
                    ListQuestionScreen.List(8);

                    //DeleteCategoryScreen.DeleteAllQuestions(questions, context);
                    // Criar no Question Delete uma opção de deletar todas as perguntas passando o ID da categoria
                    break;
                default:
                    Console.WriteLine("Opção inválida. Voltando ao menu.");
                    MenuCategoryScreen.Load();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a categoria");
            Console.WriteLine(ex.Message);
        }
    }

    private static string RemoveAccent(string word)
    {
        string text = word.Normalize(NormalizationForm.FormD);
        StringBuilder wordWithoutAccent = new StringBuilder();

        foreach (char letra in text)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(letra) != UnicodeCategory.NonSpacingMark)
            {
                wordWithoutAccent.Append(letra);
            }
        }

        return wordWithoutAccent.ToString().Normalize(NormalizationForm.FormC).ToLower();
    }
}
