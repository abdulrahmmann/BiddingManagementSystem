﻿using BiddingManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiddingManagementSystem.Infrastructure.Configurations
{
    public class BidItemConfiguration : IEntityTypeConfiguration<BidItem>
    {
        public void Configure(EntityTypeBuilder<BidItem> builder)
        {
            builder.ToTable("BidItem");

            builder.HasKey(bi => bi.Id);

            builder.Property(bi => bi.Id)
                   .HasColumnName("PK_BidItemId")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.HasIndex(bi => bi.Name).IsUnique();


            builder.Property(bi => bi.Name)
                   .HasColumnName("ItemName")
                   .HasMaxLength(16)
                   .IsRequired();

            builder.Property(bi => bi.UnitPrice).HasPrecision(18, 2);

            // builder.Property(bi => bi.TotalPrice).HasPrecision(18, 2);

            builder.Ignore(bi => bi.TotalPrice);

            builder.Property(bi => bi.Description)
                   .HasColumnName("ItemDescription")
                   .HasMaxLength(400)
                   .IsRequired();

            builder.HasOne(bi => bi.Bid)
                   .WithMany(b => b.Items)
                   .HasForeignKey(bi => bi.FK_Bid_Item_Id)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_BidItem_Bid");
        }
    }
}
