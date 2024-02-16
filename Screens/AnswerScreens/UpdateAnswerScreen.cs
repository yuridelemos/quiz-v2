using quiz_v2.Models;

namespace quiz_v2.Screens.AnswerScreens;

internal class UpdateAnswerScreen
{
    public static void Load()
    {
        Console.WriteLine("-----ATUALIZAR RESPOSTA-----");
        Console.WriteLine("(1) - Atualizar resposta");
        Console.WriteLine("(0) - Voltar");
        var option = int.Parse(Console.ReadLine());
        if (option == 0)
            MenuAnswerScreen.Load();
        Console.Clear();
        Console.WriteLine("Atualizar resposta");
        Console.WriteLine("-------------");

        Console.WriteLine();
        var questionId = ListAnswerScreen.List();

        Console.Write("Selecione a resposta: ");
        var answerOrder = Console.ReadLine();

        Console.WriteLine("Escreva a nova resposta:");
        var newBody = Console.ReadLine();


        //Update(new Answer
        //{
        //    QuestionId = questionId,
        //    AnswerOrder = int.Parse(answerOrder),
        //    Body = newBody
        //});
        Console.ReadKey();
        MenuAnswerScreen.Load();
    }

    public static void Update(Answer answer)
    {
        try
        {
            //if (CheckCorrectAnswer.CheckAnswer(answer.QuestionId) == answer.AnswerOrder)
            {
                Console.WriteLine("Aviso!: Você está alterando a resposta correta!");
                Console.WriteLine("Deseja continuar?");
                Console.WriteLine("'S' para SIM e 'N' para NÃO");
                var option = Console.ReadLine();
                if (option.ToUpper() == "N")
                    Load();
            }
            //var repository = new AnswerRepository();
            //repository.Update(answer);
            Console.WriteLine("Resposta atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a resposta");
            Console.WriteLine(ex.Message);
        }
    }
}

