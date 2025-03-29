using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Domain.Entities
{
    public class Bid
    {
        public int Id { get; private set; }
        public string CompanyName { get; private set; }
        public string RegistrationNumber { get; private set; }
        public string CompanyAddress { get; private set; }
        public string CompanyEmail { get; private set; }
        public string CompanyPhone { get; private set; }
        public string TechnicalProposal { get; private set; }
        public decimal TotalAmount { get; private set; }
        public BidStatus Status { get; private set; }
        public DateTime SubmittedAt { get; private set; }
        public DateTime? LastModifiedAt { get; private set; }

        public List<BidDocument> Documents { get; private set; } = new List<BidDocument>();
        public List<BidItem> Items { get; private set; } = new List<BidItem>();

        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //
        public int TenderId { get; private set; } // FOREIGN KEY
        public int SubmittedById { get; private set; } // FOREIGN KEY

        public Tender Tender { get; private set; }
        public User SubmittedBy { get; private set; }
    }
}
