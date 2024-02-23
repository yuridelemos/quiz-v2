using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;

namespace quiz_v2.Screens.QuestionScreens;

internal class ListQuestionScreen
{
    internal static void Load(QuizDataContext context)
    {
        Console.Clear();
        Console.WriteLine("Gestão de questões");
        Console.WriteLine("--------------");
        ListForEdit(context);
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
        Console.ReadKey();
        MenuQuestionScreen.Load(context);
    }

    internal static bool List(short id, QuizDataContext context)
    {
        try
        {
            var questions = context.Questions
                .Where(x => x.Category.Id == id)
                .AsNoTracking()
                .ToList();
            questions.Select((question) => $"{question.Id} - {question.Body}")
                .ToList()
                .ForEach(Console.WriteLine);
            if (questions.Any())
                return true;
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível listar as questões.");
            Console.WriteLine(ex.Message);
        }
        return false;
    }

    internal static void ListForEdit(QuizDataContext context)
    {
        try
        {
            var questions = context.Questions
                .AsNoTracking()
                .ToList();
            questions.Select((question) => $"{question.Id} - {question.Body}")
                .ToList()
                .ForEach(Console.WriteLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível listar as questões.");
            Console.WriteLine(ex.Message);
        }
    }
}
