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


            builder.OwnsMany(t => t.Documents, doc =>
            {
                doc.WithOwner();
                doc.Property(t => t.Name)
                   .HasColumnName("DocumentName")
                   .IsRequired()
                   .HasMaxLength(16);

                doc.Property(t => t.FilePath)
                   .HasColumnName("DocumentPath")
                   .IsRequired()
                   .HasMaxLength(255);
            });


            builder.OwnsOne(t => t.BudgetRange, money =>
            {
                money.WithOwner();
                money.Property(t => t.Amount)
                   .IsRequired();

                money.Property(t => t.Currency)
                   .IsRequired();
            });


            builder.OwnsOne(t => t.Address, add =>
            {
                add.WithOwner();

                add.Property(t => t.Country)
                   .IsRequired()
                   .HasMaxLength(16);

                add.Property(t => t.City)
                   .IsRequired()
                   .HasMaxLength(16);

                add.Property(t => t.Street)
                  .IsRequired()
                  .HasMaxLength(16);

                add.Property(t => t.ZipCode)
                  .IsRequired()
                  .HasMaxLength(16);
            });

            builder.OwnsOne(t => t.PaymentTerms, term =>
            {
                term.WithOwner();

                term.Property(t => t.PenaltyOfDelays)
                   .IsRequired();

                term.Property(t => t.AdvancePercentage)
                   .IsRequired();

                term.Property(t => t.FinalApprovalPercentage)
                   .IsRequired();

                term.Property(t => t.MilestonePercentage)
                   .IsRequired();
            });

        }
    }
}
