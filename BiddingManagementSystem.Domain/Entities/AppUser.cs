using BiddingManagementSystem.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace BiddingManagementSystem.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedAt { get; private set; }

        public UserRole Role { get; private set; } = UserRole.User;

        private AppUser() { }

        public AppUser(string userName, string email)
        {
            UserName = userName;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }


        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //

        public ICollection<Tender> CreatedTenders { get; private set; } = [];

        public ICollection<Bid> SubmittedBids { get; private set; } = [];
    }
}