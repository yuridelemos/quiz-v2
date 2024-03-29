﻿using quiz_v2.Data;

namespace quiz_v2.Screens.AnswerScreens;

internal class UpdateAnswerScreen
{
    internal static void Load(QuizDataContext context)
    {
        Console.WriteLine("-----ATUALIZAR RESPOSTA-----");
        Console.WriteLine("(1) - Atualizar resposta");
        Console.WriteLine("(0) - Voltar");
        Console.Write("----------------: ");
        var option = short.Parse(Console.ReadLine());
        if (option == 0 || option != 1)
            MenuAnswerScreen.Load(context);
        Console.Clear();
        Console.WriteLine("Atualizar resposta");
        Console.WriteLine("-------------");
        ListAnswerScreen.ListForEdit(context);
        Console.WriteLine();
        Console.Write("ID: ");
        var id = short.Parse(Console.ReadLine());
        Console.Write("Escreva a nova resposta: ");
        var body = Console.ReadLine();

        Update(id, body, context);
    }

    private static void Update(short id, string body, QuizDataContext context)
    {
        try
        {
            var answer = context.Answers
                .FirstOrDefault(x => x.Id == id);

            answer.Body = body;
            if (answer.RightAnswer)
            {
                Console.WriteLine("Aviso!: Você está alterando a resposta correta!");
                Console.WriteLine("Deseja continuar?");
                Console.WriteLine("'S' para SIM e 'N' para NÃO");
                Console.Write("----------------: ");
                var option = Console.ReadLine();
                if (option.ToUpper() == "N")
                    Load(context);
            }
            context.Answers.Update(answer);
            context.SaveChanges();
            Console.WriteLine("Resposta atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a resposta.");
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
        Console.ReadKey();
        MenuAnswerScreen.Load(context);
    }
}

