using BiddingManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;

namespace BiddingManagementSystem.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Tender> Tenders { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<BidItem> BidItems { get; set; }
        public virtual DbSet<Bidder> Bidders { get; set; }

        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);

            builder.Properties<DateOnly>()
                   .HaveConversion<DateOnlyConverter>()
                   .HaveColumnType("date");

            builder.Properties<DateTime>().HaveColumnType("datetime");
        }
    }
}
