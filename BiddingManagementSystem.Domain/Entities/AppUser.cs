using BiddingManagementSystem.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace BiddingManagementSystem.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedAt { get; private set; }

        public UserRole Role { get; private set; }

        private AppUser() { }

        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //

        public ICollection<Tender> CreatedTenders { get; private set; } = [];

        public ICollection<Bid> SubmittedBids { get; private set; } = [];
    }
}