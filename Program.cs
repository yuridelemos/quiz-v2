using quiz_v2.Data;
using quiz_v2.Screens;

using var context = new QuizDataContext();

MainMenu.Load();
context.SaveChanges();


