using BiddingManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiddingManagementSystem.Infrastructure.Configurations
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.ToTable("Evaluation");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("PK_EvaluationId")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.HasIndex(e => e.TotalScore);

            builder.Property(e => e.EvaluationDate)
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd();

            builder.HasOne(e => e.Bid)
                   .WithMany(bi => bi.Evaluations)
                   .HasForeignKey(e => e.FK_Evaluation_Bid_Id)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Evaluations_Bid");

            builder.Property(e => e.TotalScore).HasPrecision(18, 2);

            builder.ComplexProperty(bi => bi.Ev_Criteria);
        }
    }
}
