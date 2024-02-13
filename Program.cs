using quiz_v2.Data;
using quiz_v2.Models;

using var context = new QuizDataContext();

var category = context.Categories.FirstOrDefault(x => x.Id == 1);
var question = new Question
{
    Body = "Qual foi o líder militar responsável pela unificação da Alemanha em 1871?",
    Category = category
};

var answer = new Answer
{
    Question = question,
    AnswerOrder = 1,
    Body = "Otto von Bismarck",
    RightAnswer = true
};
context.Answers.Add(answer);

answer = new Answer
{
    Question = question,
    AnswerOrder = 2,
    Body = "Karl Marx",
    RightAnswer = false
};
context.Answers.Add(answer);

answer = new Answer
{
    Question = question,
    AnswerOrder = 3,
    Body = "Napoleão Bonaparte",
    RightAnswer = false
};
context.Answers.Add(answer);

answer = new Answer
{
    Question = question,
    AnswerOrder = 4,
    Body = "George Washington",
    RightAnswer = false
};
context.Answers.Add(answer);

answer = new Answer
{
    Question = question,
    AnswerOrder = 5,
    Body = "Abraham Lincoln",
    RightAnswer = false
};
context.Answers.Add(answer);

context.SaveChanges();


