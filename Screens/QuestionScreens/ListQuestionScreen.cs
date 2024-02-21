using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;

namespace quiz_v2.Screens.QuestionScreens;

internal class ListQuestionScreen
{
    internal static void Load()
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

    internal static bool List(short id)
    {
        using var context = new QuizDataContext();
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

    internal static void ListForEdit()
    {
        using var context = new QuizDataContext();
        var questions = context.Questions
            .AsNoTracking()
            .ToList();
        questions.Select((question) => $"{question.Id} - {question.Body}")
            .ToList()
            .ForEach(Console.WriteLine);
    }
}
