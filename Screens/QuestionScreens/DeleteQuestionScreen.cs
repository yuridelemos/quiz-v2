using quiz_v2.Data;
using quiz_v2.Models;
using quiz_v2.Screens.CategoryScreens;

namespace quiz_v2.Screens.QuestionScreens;

internal class DeleteQuestionScreen : GenericCRUD<Question>
{
    internal static void Load(QuizDataContext context)
    {
        Console.WriteLine("-----DELETAR QUESTÃO-----");
        Console.WriteLine("(1) - Deletar questão");
        Console.WriteLine("(0) - Voltar");
        Console.Write("-------------: ");
        var option = int.Parse(Console.ReadLine());
        Console.WriteLine("OBS: Ao deletar uma questão, todas as respostas presentes nela também serão deletadas.");
        if (option == 0 || option != 1)
            MenuQuestionScreen.Load(context);
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
                MenuQuestionScreen.Load(context);
                break;
            case 1:
                Console.WriteLine("Lista de categorias");
                Console.WriteLine("--------------");
                ListCategoryScreen.ListForEdit(context);
                Console.Write("ID: ");
                id = short.Parse(Console.ReadLine());
                emptyList = ListQuestionScreen.List(id, context);
                break;
            case 2:
                ListQuestionScreen.ListForEdit(context);
                break;
            default:
                Console.WriteLine("Opção inválida. Por favor tente novamente");
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
                Console.ReadKey();
                DeleteQuestionScreen.Load(context);
                break;
        }
        if (emptyList)
        {
            Console.Write("ID: ");
            id = short.Parse(Console.ReadLine());
            Delete(id, context);
        }
        else
        {
            Console.WriteLine("Categoria não possui questões.");
            Console.WriteLine("Pressione qualquer tecla para retornar.");
            Console.ReadKey();
            Load(context);
        }
    }


    private static void Delete(short id, QuizDataContext context)
    {
        try
        {
            Console.WriteLine($"Você tem certeza que deseja deletar essa questão?");
            Console.WriteLine("'S' para SIM e 'N' para NÃO");
            var option = Console.ReadLine();
            if (option.ToUpper() == "S")
            {
                var question = context.Questions
                    .FirstOrDefault(x => x.Id == id);
                context.Questions.Remove(question);
                context.SaveChanges();
                Console.WriteLine("Questão deletada com sucesso!");
                Thread.Sleep(2000);
                Load(context);
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor tente novamente.");
                Delete(id, context);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível deletar a questão.");
            Console.WriteLine(ex.Message);
        }

    }
    internal static void DeleteAll(Category category, QuizDataContext context)
    {
        try
        {
            new DeleteQuestionScreen().DeleteAll<Question>(context, x => x.Category.Id == category.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível deletar as questões.");
            Console.WriteLine(ex.Message);
        }
    }
}