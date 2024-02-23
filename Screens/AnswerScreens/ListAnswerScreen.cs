using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;

namespace quiz_v2.Screens.AnswerScreens;

internal class ListAnswerScreen
{
    public static void Load(QuizDataContext context)
    {
        Console.Clear();
        Console.WriteLine("Gestão de questões");
        Console.WriteLine("--------------");
        ListForEdit(context);
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
        Console.ReadKey();
        MenuAnswerScreen.Load(context);
    }

    internal static void ListForEdit(QuizDataContext context)
    {
        try
        {
            var answers = context.Answers
                .AsNoTracking()
                .ToList();
            answers.Select((answer) => $"{answer.Id} - {answer.Body}")
                .ToList()
                .ForEach(Console.WriteLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível listar as respostas.");
            Console.WriteLine(ex.Message);
        }
    }
}
