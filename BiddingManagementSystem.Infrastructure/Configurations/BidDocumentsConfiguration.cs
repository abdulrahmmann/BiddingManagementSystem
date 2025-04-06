using BiddingManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiddingManagementSystem.Infrastructure.Configurations
{
    public class BidDocumentsConfiguration : IEntityTypeConfiguration<BidDocument>
    {
        public void Configure(EntityTypeBuilder<BidDocument> builder)
        {
            builder.ToTable("BidDocuments");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                   .HasColumnName("PK_BidDocumentsId")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.HasIndex(d => d.Name);

            builder.HasOne(d => d.Bid)
                   .WithMany(b => b.BidDocuments)
                   .HasForeignKey(b => b.FK_Bid_Document_Id)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Bid_Document");
        }
    }
}
