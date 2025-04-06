using BiddingManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiddingManagementSystem.Infrastructure.Configurations
{
    public class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.ToTable("Bid");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .HasColumnName("PK_BidId")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.HasIndex(b => b.TotalBidAmount);

            builder.Property(b => b.SubmittedAt)
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.TotalBidAmount).HasPrecision(18, 2);

            // Bid - Tender -> One - to - Many
            builder.HasOne(b => b.Tender)
                   .WithMany(bi => bi.Bids)
                   .HasForeignKey(b => b.FK_Bid_Tender_Id)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Bid_Tender");

            // Bid - Bidder -> One - to - One
            builder.HasOne(b => b.Bidder)
                   .WithMany(bi => bi.Bids)
                   .HasForeignKey(b => b.FK_Bid_Bidder_Id)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Bid_Bidder");

            // Bid - User -> One - to - One
            builder.HasOne(b => b.User)
                   .WithMany(bi => bi.SubmittedBids)
                   .HasForeignKey(b => b.FK_Bid_User_Id)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Bid_User");
        }
    }
}
