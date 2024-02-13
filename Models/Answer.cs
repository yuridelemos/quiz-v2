namespace quiz_v2.Models;

public class Answer
{
    public int Id { get; set; }
    public Question Question { get; set; }
    public int AnswerOrder { get; set; }
    public string Body { get; set; }
    public bool RightAnswer { get; set; }
}
