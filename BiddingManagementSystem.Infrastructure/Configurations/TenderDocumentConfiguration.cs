using BiddingManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiddingManagementSystem.Infrastructure.Configurations
{
    public class TenderDocumentConfiguration : IEntityTypeConfiguration<TenderDocument>
    {
        public void Configure(EntityTypeBuilder<TenderDocument> builder)
        {
            builder.ToTable("TenderDocuments");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                   .HasColumnName("PK_TenderDocumentsId")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.HasIndex(d => d.Name);

            builder.HasOne(t => t.Tender)
                   .WithMany(d => d.TenderDocument)
                   .HasForeignKey(t => t.FK_Tender_Document_Id)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Tender_Document");
        }
    }
}
