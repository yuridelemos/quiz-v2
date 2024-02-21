using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;
using quiz_v2.Screens.AnswerScreens;
using quiz_v2.Screens.CategoryScreens;

namespace quiz_v2.Screens.QuestionScreens;

internal class UpdateQuestionScreen
{
    public static void Load()
    {
        Console.WriteLine("-----ATUALIZAR QUESTÃO-----");
        Console.WriteLine("(1) - Atualizar questão");
        Console.WriteLine("(0) - Voltar");
        var option = short.Parse(Console.ReadLine());
        if (option == 0)
            MenuQuestionScreen.Load();
        Console.Clear();
        Console.WriteLine("Atualizar questão");
        Console.WriteLine("-------------");
        ListQuestionScreen.ListForEdit();
        Console.Write("ID: ");
        var id = short.Parse(Console.ReadLine());
        Console.Write("Escreva a nova questão: ");
        var body = Console.ReadLine();

        Update(id, body);
    }

    private static void Update(short id, string body)
    {
        using var context = new QuizDataContext();
        try
        {
            var question = context
                .Questions
                .Include(x => x.Answers)
                .FirstOrDefault(x => x.Id == id);

            question.Body = body;

            context.Questions.Update(question);
            context.SaveChanges();

            Console.WriteLine("Questão atualizada com sucesso!");
            Console.WriteLine("Você deseja apagar todas as respostas dessa questão?");
            Console.WriteLine("(1) - Sim, desejo apagar todas as respostas.");
            Console.WriteLine("(0) - Não, desejo voltar ao menu.");
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                    MenuCategoryScreen.Load();
                    break;
                case 1:
                    DeleteAnswerScreen.DeleteAllAnswers(question, context);
                    Console.WriteLine("Questões apagadas com sucesso.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Voltando ao menu.");
                    MenuCategoryScreen.Load();
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a categoria");
            Console.WriteLine(ex.Message);
        }
    }
}