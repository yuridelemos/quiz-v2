namespace quiz_v2.Screens.QuestionScreens;

internal class UpdateQuestionScreen
{
    public static void Load()
    {
        System.Console.WriteLine("-----ATUALIZAR QUESTÃO-----");
        System.Console.WriteLine("(1) - Atualizar questão");
        System.Console.WriteLine("(0) - Voltar");
        var option = int.Parse(Console.ReadLine());
        if (option == 0)
            MenuQuestionScreen.Load();
        Console.Clear();
        Console.WriteLine("Atualizar questão");
        Console.WriteLine("-------------");

        Console.Write("ID: ");
        var id = Console.ReadLine();
        Console.Write("Escreva a nova questão: ");
        var body = Console.ReadLine();
    }
}