using BiddingManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiddingManagementSystem.Infrastructure.Configurations
{
    public class BidderConfiguration : IEntityTypeConfiguration<Bidder>
    {
        public void Configure(EntityTypeBuilder<Bidder> builder)
        {
            builder.ToTable("Bidder");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .HasColumnName("PK_BidderId")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.HasOne(t => t.Tender)
                .WithMany(b => b.Bidders)
                .HasForeignKey(t => t.FK_Bidder_Tender_Id)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Bidder_Tender");
        }
    }
}
