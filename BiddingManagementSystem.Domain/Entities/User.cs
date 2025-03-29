using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserRole Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastLogin { get; private set; }
        public bool IsActive { get; private set; }

        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //
        public List<Tender> CreatedTenders { get; private set; } = new List<Tender>();
        public List<Bid> SubmittedBids { get; private set; } = new List<Bid>();
    }
}
