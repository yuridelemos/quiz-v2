namespace quiz_v2.Screens.QuestionScreens;

public class DeleteQuestionScreen
{
    public static void Load()
    {
        System.Console.WriteLine("-----DELETAR QUESTÃO-----");
        System.Console.WriteLine("(1) - Deletar questão");
        System.Console.WriteLine("(0) - Voltar");
        var option = int.Parse(Console.ReadLine());
        System.Console.WriteLine("OBS: Ao deletar uma questão, todas as respostas presentes nela também serão deletadas.");
        if (option == 0)
            MenuQuestionScreen.Load();
        Console.Clear();
        Console.WriteLine("Deletar questão");
        Console.WriteLine("-------------");


        System.Console.WriteLine();
        Console.Write("ID: ");
        var id = Console.ReadLine();


        //    try
        //    {
        //        System.Console.WriteLine($"Você tem certeza que deseja deletar essa questão?");
        //        System.Console.WriteLine("'S' para SIM e 'N' para NÃO");
        //var option = Console.ReadLine();
        //if (option.ToUpper() == "S")
        //{
        //    DeleteAnswerScreen.DeleteAll(new Answer
        //    {
        //        QuestionId = question.Id
        //    });
        //    var repository = new Repository<Question>();
        //    repository.Delete(question);
        Console.WriteLine("Questão deletada com sucesso!");
        Thread.Sleep(2000);
    }
    //            Load();
    //}
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("Não foi possível deletar questão");
    //            Console.WriteLine(ex.Message);
    //        }
}