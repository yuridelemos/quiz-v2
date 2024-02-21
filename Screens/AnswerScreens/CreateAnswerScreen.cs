using quiz_v2.Data;
using quiz_v2.Models;

namespace quiz_v2.Screens.AnswerScreens;

internal class CreateAnswerScreen
{
    internal static void Load(Question question, QuizDataContext context, int answerOrder)
    {
        Console.WriteLine("Nova resposta");
        Console.WriteLine("-------------");
        Console.Write("Digite a resposta: ");
        var body = Console.ReadLine();
        var rightAnswer = false;
        if (answerOrder == 1)
            rightAnswer = true;
        Create(new Answer
        {
            Question = question,
            AnswerOrder = answerOrder,
            Body = body,
            RightAnswer = rightAnswer
        }, context);
    }

    private static void Create(Answer answer, QuizDataContext context)
    {
        try
        {
            context.Answers.Add(answer);
            Console.Clear();
            Console.WriteLine($"Resposta {answer.AnswerOrder} salva com sucesso!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar a resposta");
            Console.WriteLine(ex.Message);
        }
    }
}

