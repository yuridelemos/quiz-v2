using quiz_v2.Data;
using quiz_v2.Models;

namespace quiz_v2.Screens.CategoryScreens;

internal class DeleteCategoryScreen
{
    private static void Delete()
    {

    }

    internal static void DeleteAllQuestions(Category category, QuizDataContext context)
    {
        var questions = context.Questions
                        .Where(x => x.Category.Id == category.Id)
                        .ToList();
        foreach (var question in questions)
            context.Questions.Remove(question);
    }
}
