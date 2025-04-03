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

        private User() { }

        public User(string name, string email, string password, UserRole role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            CreatedAt = DateTime.UtcNow;
        }

        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //

        public ICollection<Tender> CreatedTenders { get; private set; } = [];

        public ICollection<Bid> SubmittedBids { get; private set; } = [];
    }
}