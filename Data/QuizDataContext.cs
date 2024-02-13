using Microsoft.EntityFrameworkCore;
using quiz_v2.Data.Mappings;
using quiz_v2.Models;

namespace quiz_v2.Data;

public class QuizDataContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=Sh@rk250535;Trusted_Connection=False; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new QuestionMap());
        modelBuilder.ApplyConfiguration(new AnswerMap());
    }

}
