using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public DateTime CreatedAt { get; private set; }

        public UserRole Role { get; private set; } // ENUM

        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //

        public List<Tender> CreatedTenders { get; private set; } = new List<Tender>();

        public List<Bid> SubmittedBids { get; private set; } = new List<Bid>();
    }
}