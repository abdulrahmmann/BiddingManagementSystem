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

            builder.Property(t => t.Deadline)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.IssueDate)
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd();

            builder.Property(t => t.ClosingDate)
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd();


            builder.Property(t => t.Email)
                   .HasColumnName("Email")
                   .IsRequired();


            builder.HasOne(t => t.User)
                   .WithMany(u => u.CreatedTenders)
                   .HasForeignKey(t => t.FK_Tender_User_Id)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Tender_User_ReferenceNumber");

            builder.ComplexProperty(t => t.ElgCriteria, owned =>
            {
                owned.Property(owned => owned.RequiresBusinessLicense).HasColumnName("ElgC_ReqBizLicense");
                owned.Property(owned => owned.MinimumExperienceYears).HasColumnName("ElgC_MinExpYears");
                owned.Property(owned => owned.FinancialStabilityRequirement).HasColumnName("ElgC_FinStabReq");
                owned.Property(owned => owned.IndustryCompliance).HasColumnName("ElgC_IndComp");
            });


            builder.ComplexProperty(t => t.BudgetRange);

            builder.ComplexProperty(t => t.Address, adr =>
            {
                adr.Property(t => t.Country)
                   .IsRequired()
                   .HasMaxLength(16);
                adr.Property(t => t.City)
                   .IsRequired()
                   .HasMaxLength(16);
                adr.Property(t => t.Street)
                  .IsRequired()
                  .HasMaxLength(16);
                adr.Property(t => t.ZipCode)
                  .IsRequired()
                  .HasMaxLength(16);
            });

            builder.ComplexProperty(t => t.PaymentTerms);
        }
    }
}
