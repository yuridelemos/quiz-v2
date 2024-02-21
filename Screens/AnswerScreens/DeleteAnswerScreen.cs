using quiz_v2.Data;
using quiz_v2.Models;

namespace quiz_v2.Screens.AnswerScreens;

internal class DeleteAnswerScreen
{
    public static void DeleteAll(Answer answer)
    {
        try
        {
            //var repository = new AnswerRepository();
            //repository.Delete(answer);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível deletar as respostas");
            Console.WriteLine(ex.Message);
        }
    }

    internal static void DeleteAllAnswers(Question question, QuizDataContext context)
    {
        var answers = context.Answers
                        .Where(x => x.Question.Id == question.Id)
                        .ToList();
        foreach (var answer in answers)
            context.Answers.Remove(answer);
        context.SaveChanges();
    }
}
