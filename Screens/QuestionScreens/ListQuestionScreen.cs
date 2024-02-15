namespace quiz_v2.Screens.QuestionScreens;

internal class ListQuestionScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestão de questões");
        Console.WriteLine("--------------");
        Console.WriteLine();
        System.Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
        Console.ReadKey();
        MenuQuestionScreen.Load();
    }
}
