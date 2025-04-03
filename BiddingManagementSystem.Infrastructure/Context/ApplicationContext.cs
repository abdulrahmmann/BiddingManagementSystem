using BiddingManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
