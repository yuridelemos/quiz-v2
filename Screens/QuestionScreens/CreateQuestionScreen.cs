using quiz_v2.Screens.CategoryScreens;

namespace quiz_v2.Screens.QuestionScreens;

internal class CreateQuestionScreen
{
    public void Create()
    {
        Console.WriteLine("-----CRIAR QUESTÃO-----");
        Console.WriteLine("(1) - Criar questão");
        Console.WriteLine("(0) - Voltar");
        var option = int.Parse(Console.ReadLine());
        if (option == 0)
            MenuQuestionScreen.Load();
        Console.Clear();
        Console.WriteLine("Nova questão");
        Console.WriteLine("-------------");
        Console.WriteLine("Ao criar uma nova questão, será obrigado logo em seguida a colocação das 5 alternativas de respostas.");
        Console.WriteLine("A primeia resposta será automaticamente considerada a verdadeira, então cuidado! Mas não se preocupe, no quiz elas terão ordens embaralhadas.");
        ListCategoryScreen.List();
        Console.Write("Categoria da questão: ");
        var categoryId = short.Parse(Console.ReadLine());
        Console.WriteLine("Digite a questão");
        var body = Console.ReadLine();
    }
}
