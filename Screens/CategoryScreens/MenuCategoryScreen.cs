namespace quiz_v2.Screens.CategoryScreens;

internal class MenuCategoryScreen
{
    internal static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestão de cartegorias");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("(1) - Listar cartegorias");
        Console.WriteLine("(2) - Cadastrar cartegorias");
        Console.WriteLine("(3) - Atualizar cartegorias");
        Console.WriteLine("(4) - Excluir cartegorias");
        Console.WriteLine("(0) - Voltar");
        Console.Write("----------------: ");

        var option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                ListCategoryScreen.Load();
                break;
            case 2:
                CreateCategoryScreen.Load();
                break;
            case 3:
                UpdateCategoryScreen.Load();
                break;
            case 4:
                DeleteCategoryScreen.Load();
                break;
            case 0:
                MainMenu.Start();
                break;
            default:
                Console.WriteLine("Opção digitada inválida, pressione qualquer tecla para retornar ao menu.");
                Console.ReadKey();
                Load();
                break;
        }
    }
}
