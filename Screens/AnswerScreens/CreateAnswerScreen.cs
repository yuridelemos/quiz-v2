using quiz_v2.Models;

namespace quiz_v2.Screens.AnswerScreens;

internal class CreateAnswerScreen
{
    public static void Load(Question question, int count)
    {
        Console.WriteLine("Nova resposta");
        Console.WriteLine("-------------");
        var answerOrder = count;
        Console.WriteLine("Digite a resposta");
        var body = Console.ReadLine();
        System.Console.WriteLine("Essa resposta é a correta? \"S\" Sim e \"N\" Não");
        var option = Console.ReadLine().ToUpper();
        var rightAnswer = false;
        if (option == "S" || option == "SIM")
            rightAnswer = true;
        //Create(new Answer
        //{
        //    QuestionId = question.Id,
        //    AnswerOrder = answerOrder,
        //    Body = body,
        //    RightAnswer = rightAnswer
        //});
    }

    public static void Create(Answer answer)
    {
        try
        {
            //var repository = new AnswerRepository();
            //repository.Insert(answer);
            System.Console.WriteLine("Resposta salva com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar a resposta");
            Console.WriteLine(ex.Message);
        }
    }
}

