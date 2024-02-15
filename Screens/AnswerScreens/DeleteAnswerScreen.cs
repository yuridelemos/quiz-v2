using quiz_v2.Models;

namespace quiz_v2.Screens.AnswerScreens;

internal class DeleteAnswerScreen
{
    public static void DeleteAll(Answer answer)
    {
        try
        {
            //var repository = new AnswerRepository();
            //repository.Delete(answer);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível deletar as respostas");
            Console.WriteLine(ex.Message);
        }
    }
}
