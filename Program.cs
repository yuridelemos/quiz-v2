using quiz_v2.Data;
using quiz_v2.Screens.CategoryScreens;

using var context = new QuizDataContext();
ListCategoryScreen.List();
UpdateCategoryScreen.Load();
ListCategoryScreen.List();
//MainMenu.Start();
//var category = context.Categories.FirstOrDefault(x => x.Id == 1);

//context.SaveChanges();

//StartGame.Load();

