using quiz_v2.Data;

namespace quiz_v2.Screens.QuestionScreens;

public class ListQuestionScreen
{
    public static void List(int id)
    {
        Console.Clear();
        Console.WriteLine("Gestão de questões");
        Console.WriteLine("--------------");
        using var context = new QuizDataContext();
        var questions = context.Questions
            .Where(x => x.Category.Id == id)
            .ToList();
        questions.Select((question) => $"{question.Id} - {question.Body}")
            .ToList()
            .ForEach(Console.WriteLine);
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
        Console.ReadKey();
        //MenuQuestionScreen.Load();
    }
}
