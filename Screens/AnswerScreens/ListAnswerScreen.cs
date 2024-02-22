using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;
using quiz_v2.Screens.QuestionScreens;

namespace quiz_v2.Screens.AnswerScreens;

internal class ListAnswerScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestão de questões");
        Console.WriteLine("--------------");
        ListForEdit();
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
        Console.ReadKey();
        MenuQuestionScreen.Load();
    }

    internal static void ListForEdit()
    {
        try
        {
            using var context = new QuizDataContext();
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
