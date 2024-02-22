using quiz_v2.Data;
using quiz_v2.Models;
using quiz_v2.Screens.CategoryScreens;

namespace quiz_v2.Screens.QuestionScreens;

internal class DeleteQuestionScreen
{
    internal static void Load()
    {
        Console.WriteLine("-----DELETAR QUESTÃO-----");
        Console.WriteLine("(1) - Deletar questão");
        Console.WriteLine("(0) - Voltar");
        Console.Write("-------------: ");
        var option = int.Parse(Console.ReadLine());
        Console.WriteLine("OBS: Ao deletar uma questão, todas as respostas presentes nela também serão deletadas.");
        if (option == 0)
            MenuQuestionScreen.Load();
        Console.Clear();
        Console.WriteLine("-----DELETAR QUESTÃO-----");
        Console.WriteLine("-------------");
        Console.WriteLine("(1) - Visualizar questão por categoria");
        Console.WriteLine("(2) - Visualizar todas as questões");
        Console.WriteLine("(0) - Voltar");
        Console.Write("-------------: ");
        option = int.Parse(Console.ReadLine());
        short id;
        bool emptyList = true;
        switch (option)
        {
            case 0:
                MenuQuestionScreen.Load();
                break;
            case 1:
                Console.WriteLine("Lista de categorias");
                Console.WriteLine("--------------");
                ListCategoryScreen.ListForEdit();
                Console.Write("ID: ");
                id = short.Parse(Console.ReadLine());
                emptyList = ListQuestionScreen.List(id);
                break;
            case 2:
                ListQuestionScreen.ListForEdit();
                break;
            default:
                Console.WriteLine("Opção inválida. Por favor tente novamente");
                break;
        }
        if (emptyList)
        {
            Console.Write("ID: ");
            id = short.Parse(Console.ReadLine());
            Delete(id);
        }
        else
        {
            Console.WriteLine("Categoria não possui questões.");
            Console.WriteLine("Pressione qualquer tecla para retornar.");
            Console.ReadKey();
            Load();
        }
    }


    private static void Delete(short id)
    {
        try
        {
            Console.WriteLine($"Você tem certeza que deseja deletar essa questão?");
            Console.WriteLine("'S' para SIM e 'N' para NÃO");
            var option = Console.ReadLine();
            if (option.ToUpper() == "S")
            {
                using var context = new QuizDataContext();
                var question = context.Questions
                    .FirstOrDefault(x => x.Id == id);
                context.Questions.Remove(question);
                context.SaveChanges();
                Console.WriteLine("Questão deletada com sucesso!");
                Thread.Sleep(2000);
                Load();
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor tente novamente.");
                Delete(id);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível deletar a questão.");
            Console.WriteLine(ex.Message);
        }

    }
    internal static void DeleteAllQuestions(Category category, QuizDataContext context)
    {
        try
        {
            var questions = context.Questions
                            .Where(x => x.Category.Id == category.Id)
                            .ToList();
            foreach (var question in questions)
                context.Questions.Remove(question);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível deletar as questões.");
            Console.WriteLine(ex.Message);
        }
    }
}