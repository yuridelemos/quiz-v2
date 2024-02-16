using quiz_v2.Data;
using quiz_v2.Screens.CategoryScreens;
using quiz_v2.Screens.QuestionScreens;

using var context = new QuizDataContext();
ListQuestionScreen.List(8);
UpdateCategoryScreen.Load();
ListQuestionScreen.List(8);
//MainMenu.Start();
//var category = context.Categories.FirstOrDefault(x => x.Id == 1);

//context.SaveChanges();

//StartGame.Load();

