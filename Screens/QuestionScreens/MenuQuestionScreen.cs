using quiz_v2.Data;

namespace quiz_v2.Screens.QuestionScreens;

public class MenuQuestionScreen
{
    public static void Load(QuizDataContext context)
    {
        Console.Clear();
        Console.WriteLine("Gestão de questões");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("(1) - Listar questões");
        Console.WriteLine("(2) - Cadastrar questões");
        Console.WriteLine("(3) - Atualizar questões");
        Console.WriteLine("(4) - Excluir questões");
        Console.WriteLine("(0) - Voltar");
        Console.Write("----------------: ");

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                ListQuestionScreen.Load(context);
                break;
            case 2:
                CreateQuestionScreen.Load(context);
                break;
            case 3:
                UpdateQuestionScreen.Load(context);
                break;
            case 4:
                DeleteQuestionScreen.Load(context);
                break;
            case 0:
                MainMenu.Load(context);
                break;
            default:
                Console.WriteLine("Opção digitada inválida, pressione qualquer tecla para retornar ao menu.");
                Console.ReadKey();
                Load(context);
                break;
        }
    }
}
