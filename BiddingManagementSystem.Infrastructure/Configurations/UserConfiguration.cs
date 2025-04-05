/*
using BiddingManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiddingManagementSystem.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .HasColumnName("UserId")
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Name)
                   .HasColumnName("UserName")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.Email)
                   .HasColumnName("Email")
                   .IsRequired();

            builder.Property(u => u.Password)
                   .HasColumnName("Password")
                   .IsRequired();

            builder.Property(u => u.CreatedAt)
                   .HasColumnName("CreatedAt")
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd();

            builder.Property(u => u.Role)
                   .HasColumnName("UserRole")
                   .HasConversion<string>()
                   .IsRequired();
        }
    }
}
*/