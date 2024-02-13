namespace quiz_v2.Models;

public class Question
{
    public int Id { get; set; }
    public string Body { get; set; }
    public Category Category { get; set; }
    public IList<Answer> Answers { get; set; }

}
