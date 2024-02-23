using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;
using quiz_v2.Screens.AnswerScreens;
using quiz_v2.Screens.CategoryScreens;

namespace quiz_v2.Screens.QuestionScreens;

internal class UpdateQuestionScreen
{
    public static void Load(QuizDataContext context)
    {
        Console.WriteLine("-----ATUALIZAR QUESTÃO-----");
        Console.WriteLine("(1) - Atualizar questão");
        Console.WriteLine("(0) - Voltar");
        Console.Write("----------------: ");
        var option = short.Parse(Console.ReadLine());
        if (option == 0)
            MenuQuestionScreen.Load(context);
        Console.Clear();
        Console.WriteLine("Atualizar questão");
        Console.WriteLine("-------------");
        ListQuestionScreen.ListForEdit(context);
        Console.Write("ID: ");
        var id = short.Parse(Console.ReadLine());
        Console.Write("Escreva a nova questão: ");
        var body = Console.ReadLine();

        Update(id, body, context);
    }

    private static void Update(short id, string body, QuizDataContext context)
    {
        try
        {
            var question = context
                .Questions
                .Include(x => x.Answers)
                .FirstOrDefault(x => x.Id == id);

            question.Body = body;

            context.Questions.Update(question);
            context.SaveChanges();

            Console.WriteLine("Você deseja apagar todas as respostas dessa questão?");
            Console.WriteLine("(1) - Sim, desejo apagar todas as respostas.");
            Console.WriteLine("(0) - Não, desejo voltar ao menu.");
            Console.Write("----------------: ");
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                    Console.WriteLine("Questão atualizada com sucesso!");
                    break;
                case 1:
                    Console.WriteLine("Questão atualizada com sucesso!");
                    DeleteAnswerScreen.DeleteAllAnswers(question, context);
                    Console.WriteLine("Respostas apagadas com sucesso.");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Voltando ao menu.");
                    break;
            }
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
            MenuCategoryScreen.Load(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a categoria.");
            Console.WriteLine(ex.Message);
        }
    }
}