namespace quiz_v2.Screens;

public class RulesScreen
{
    public static void ShowRules()
    {
        Console.Clear();
        Console.WriteLine("--------------- REGRAS DO JOGO ---------------");
        Console.WriteLine("O jogo é composto por uma série de perguntas.");
        Console.WriteLine("Você deverá responder corretamente o maior número de perguntas possível.");
        Console.WriteLine("Para cada pergunta respondida corretamente, você ganha pontos.");
        Console.WriteLine("Você pode escolher quantas perguntas deseja responder (máximo de 20), mas caso não escolha, a quantidade será de 10 perguntas.");
        Console.WriteLine("O jogo termina quando você responde todas as perguntas ou quando desiste.");
        Console.WriteLine("A desistência ocorre quando é apertado 0.");
        Console.WriteLine("Boa sorte e divirta-se!\n");
    }
}
