using quiz_v2.Data;

namespace quiz_v2.Screens.AnswerScreens;

public class MenuAnswerScreen
{
    public static void Load(QuizDataContext context)
    {
        Console.Clear();
        Console.WriteLine("Gestão de respostas");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("(1) - Listar respostas");
        Console.WriteLine("(2) - Atualizar respostas");
        Console.WriteLine("(0) - Voltar");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                ListAnswerScreen.Load(context);
                break;
            case 2:
                UpdateAnswerScreen.Load(context);
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
