namespace quiz_v2.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public IList<Question> Questions { get; set; }
}
