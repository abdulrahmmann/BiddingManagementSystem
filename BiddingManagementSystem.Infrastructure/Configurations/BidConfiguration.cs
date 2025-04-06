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
                   .HasColumnName("BidId")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.HasIndex(b => b.UserId);

            builder.Property(b => b.SubmittedAt)
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd();

            // Bid - Tender -> One - to - Many
            builder.HasOne(b => b.Tender)
                   .WithMany()
                   .HasForeignKey(b => b.TenderId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Bid_Tender");

            // Bid - Bidder -> One - to - One
            builder.HasOne(b => b.Bidder)
                   .WithMany()
                   .HasForeignKey(b => b.BidderId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Bid_Bidder");

            // Bid - User -> One - to - One
            builder.HasOne(b => b.User)
                   .WithMany()
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Bid_User");

            builder.HasMany(b => b.BidDocuments)
                   .WithOne()
                   .HasForeignKey(b => b.BidDocumentId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Bid_Document");
        }
    }
}
