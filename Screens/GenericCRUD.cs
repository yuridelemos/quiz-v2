using quiz_v2.Data;
using System.Linq.Expressions;

namespace quiz_v2.Screens;

abstract class GenericCRUD<T>
{
    internal void DeleteAll<T>(QuizDataContext context, Expression<Func<T, bool>> condition)
        where T : class
    {
        try
        {
            var entities = context.Set<T>().Where(condition).ToList();
            foreach (var entity in entities)
                context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível deletar os dados.");
            Console.WriteLine(ex.Message);
        }
    }
}
