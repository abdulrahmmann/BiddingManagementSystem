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
                   .HasColumnName("BidderId")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();
        }
    }
}
