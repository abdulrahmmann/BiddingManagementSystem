using BiddingManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiddingManagementSystem.Infrastructure.Configurations
{
    public class TenderConfiguration : IEntityTypeConfiguration<Tender>
    {
        public void Configure(EntityTypeBuilder<Tender> builder)
        {
            builder.ToTable("Tender");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasColumnName("TenderId")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.HasIndex(t => t.Title);

            builder.Property(t => t.Title)
                   .HasColumnName("TenderTitle")
                   .HasMaxLength(60);


            builder.Property(t => t.Description)
                   .HasColumnName("TenderDescription")
                   .HasMaxLength(400);

            builder.Property(t => t.IssuedBy)
                   .HasColumnName("IssuedBy")
                   .HasMaxLength(400);

            builder.Property(t => new { t.Deadline, t.IssueDate, t.ClosingDate })
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd();

            builder.Property(t => t.Email)
                   .HasColumnName("Email")
                   .IsRequired();


            builder.HasOne(t => t.User)
                   .WithMany()
                   .HasForeignKey(t => t.CreatedById)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Tender_User");
        }
    }
}
