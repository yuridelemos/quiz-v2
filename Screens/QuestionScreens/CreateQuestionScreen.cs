using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;
using quiz_v2.Models;
using quiz_v2.Screens.AnswerScreens;
using quiz_v2.Screens.CategoryScreens;

namespace quiz_v2.Screens.QuestionScreens;

internal class CreateQuestionScreen
{
    internal static void Load(QuizDataContext context)
    {
        Console.WriteLine("-----CRIAÇÃO DE QUESTÃO-----");
        Console.WriteLine("(1) - Criar questão");
        Console.WriteLine("(0) - Voltar");
        Console.Write("-------------: ");
        var option = short.Parse(Console.ReadLine());
        if (option == 0 || option != 1)
            MenuQuestionScreen.Load(context);
        Console.Clear();
        Console.WriteLine("Nova questão");
        Console.WriteLine("-------------");
        Console.WriteLine("Ao criar uma nova questão, será obrigado logo em seguida a colocação das 5 alternativas de respostas.");
        Console.WriteLine("A primeia resposta será automaticamente considerada a verdadeira, então cuidado! Mas não se preocupe, no quiz elas terão ordens embaralhadas.");
        ListCategoryScreen.ListForEdit(context);
        Create(context);
    }
    private static void Create(QuizDataContext context)
    {
        try
        {
            Console.Write("Categoria da questão: ");
            var categoryId = short.Parse(Console.ReadLine());
            var category = context.Categories.FirstOrDefault(x => x.Id == categoryId);
            Console.Write("Digite a questão: ");
            var body = Console.ReadLine();
            CheckDuplicity(context, body);

            var question = new Question
            {
                Category = category,
                Body = body
            };
            context.Questions.Add(question);
            for (int i = 1; i < 6; i++)
            {
                if (i == 1)
                    Console.WriteLine("Lembrete: a primeira resposta inserida será considerada a correta.");
                Console.WriteLine($"Resposta {i} ");
                CreateAnswerScreen.Load(question, context, i);
            }
            context.SaveChanges();
            Console.WriteLine("Questão cadastrada com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
            MenuQuestionScreen.Load(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar a questão");
            Console.WriteLine(ex.Message);
        }
    }
    private static void CheckDuplicity(QuizDataContext context, string body)
    {
        var questions = context.Questions
                        .AsNoTracking()
                        .ToList();
        foreach (var question in questions)
        {
            if (question == null || question.Body == body)
            {
                Console.WriteLine("Não foi possível efetuar o cadastrar, questão já cadastrada.");
                Console.WriteLine("Presione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Load(context);
            }
        }
    }
}
