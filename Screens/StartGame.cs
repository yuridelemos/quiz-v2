using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;

namespace quiz_v2.Screens;

internal class StartGame
{
    internal static void Load(QuizDataContext context)
    {
        Console.WriteLine("-------------Iniciando o jogo-------------");
        Console.WriteLine("Escolha a quantidade de questões para iniciar seu quiz");
        Console.WriteLine("Você pode escolher quantas perguntas deseja responder (máximo de 20), mas caso não escolha, a quantidade será de 10 perguntas.");
        Console.Write("----------------: ");
        var numberOfQuestions = short.Parse(Console.ReadLine());
        if (numberOfQuestions > 20)
            numberOfQuestions = 20;
        else if (numberOfQuestions < 0)
            numberOfQuestions = 10;
        Random rand = new Random();
        int rightQuestions = 0, questionNumber = 1;
        List<int> questionsAlreadyAsked = new List<int>();

        var questions = context
            .Questions
            .AsNoTracking()
            .Include(x => x.Answers)
            .ToList();

        foreach (var question in questions.OrderBy(x => rand.Next()))
        {
            if (!questionsAlreadyAsked.Any(x => x == question.Id))
            {
                List<bool> options = new List<bool>();
                int i = 0;
                Console.WriteLine($"({questionNumber}) - {question.Body}");
                foreach (var answer in question.Answers.OrderBy(x => rand.Next()))
                {
                    if (answer.Question.Id == question.Id)
                    {
                        Console.WriteLine($"{i + 1} - {answer.Body}");
                        options.Add(answer.RightAnswer);
                        i++;
                    }
                }
                Console.WriteLine("Qual a resposta correta?");
                Console.Write("======================: ");
                var SelectAnswer = int.Parse(Console.ReadLine());
                if (options[SelectAnswer - 1] == true) // Criar um tratamento para opção maior que 5 e menor que 1
                {
                    Console.WriteLine("Certa resposta!");
                    rightQuestions++;
                }
                else
                    Console.WriteLine("Resposta errada!");
                questionsAlreadyAsked.Add(question.Id);
            }
            if (questionNumber == 10)
                break;
            numberOfQuestions--;
            questionNumber++;
        }
        Console.WriteLine($"Seu resultado foi de {rightQuestions} acertos!");
    }
}
