using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quiz_v2.Models;

namespace quiz_v2.Data.Mappings;

public class AnswerMap : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("Answer");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.AnswerOrder)
            .IsRequired()
            .HasColumnName("AnswerOrder")
            .HasColumnType("INT");

        builder.Property(x => x.Body)
            .IsRequired()
            .HasColumnName("Body")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(250);

        builder.Property(x => x.RightAnswer)
            .IsRequired()
            .HasColumnName("RightAnswer")
            .HasColumnType("BIT");

        builder.HasOne(X => X.Question)
            .WithMany(x => x.Answers)
            .HasConstraintName("FK_Answer_Question")
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}
