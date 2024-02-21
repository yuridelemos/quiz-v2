using quiz_v2.Data;

namespace quiz_v2.Screens.AnswerScreens;

internal class UpdateAnswerScreen
{
    internal static void Load()
    {
        Console.WriteLine("-----ATUALIZAR RESPOSTA-----");
        Console.WriteLine("(1) - Atualizar resposta");
        Console.WriteLine("(0) - Voltar");
        var option = short.Parse(Console.ReadLine());
        if (option == 0)
            MenuAnswerScreen.Load();
        Console.Clear();
        Console.WriteLine("Atualizar resposta");
        Console.WriteLine("-------------");
        ListAnswerScreen.ListForEdit();
        Console.WriteLine();
        Console.Write("ID: ");
        var id = short.Parse(Console.ReadLine());
        Console.WriteLine("Escreva a nova resposta:");
        var body = Console.ReadLine();

        Update(id, body);
    }

    private static void Update(short id, string body)
    {
        try
        {
            using var context = new QuizDataContext();
            var answer = context.Answers
                .FirstOrDefault(x => x.Id == id);

            answer.Body = body;
            if (answer.RightAnswer)
            {
                Console.WriteLine("Aviso!: Você está alterando a resposta correta!");
                Console.WriteLine("Deseja continuar?");
                Console.WriteLine("'S' para SIM e 'N' para NÃO");
                var option = Console.ReadLine();
                if (option.ToUpper() == "N")
                    Load();
            }
            context.Answers.Update(answer);
            context.SaveChanges();
            Console.WriteLine("Resposta atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a resposta");
            Console.WriteLine(ex.Message);
        }
    }
}

