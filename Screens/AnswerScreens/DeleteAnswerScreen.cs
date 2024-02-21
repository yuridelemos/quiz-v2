using quiz_v2.Data;
using quiz_v2.Models;

namespace quiz_v2.Screens.AnswerScreens;

internal class DeleteAnswerScreen
{
    internal static void DeleteAllAnswers(Question question, QuizDataContext context)
    {
        try
        {
            var answers = context.Answers
                .Where(x => x.Question.Id == question.Id)
                .ToList();
            foreach (var answer in answers)
                context.Answers.Remove(answer);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível deletar as respostas");
            Console.WriteLine(ex.Message);
        }
    }
}
