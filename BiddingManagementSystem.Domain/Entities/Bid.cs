using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Domain.Entities
{
    public class Bid
    {
        public int Id { get; private set; }

        public string TechnicalProposal { get; private set; } = string.Empty;

        public string FinancialProposal { get; private set; } = string.Empty;

        public decimal TotalBidAmount { get; private set; }

        public BidStatus Status { get; private set; } // ENUM

        public DateTime SubmittedAt { get; private set; }

        private readonly List<BidItem> _items = [];
        public IReadOnlyCollection<BidItem> Items => _items.AsReadOnly();

        private Bid() { }

        public Bid(string technicalProposal, decimal totalBidAmount, BidStatus status, DateTime submittedAt)
        {
            TechnicalProposal = technicalProposal;
            TotalBidAmount = totalBidAmount;
            Status = status;
            SubmittedAt = submittedAt;
        }

        public void AddItem(string description, int quantity, decimal unitPrice)
        {
            var bidItem = new BidItem(description, quantity, unitPrice);
            _items.Add(bidItem);
        }

        public void RemoveItem(BidItem item)
        {
            if (!_items.Contains(item)) throw new InvalidOperationException("Item not found in the bid.");
            _items.Remove(item);
        }

        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //

        // FOREIGN KEYS
        public int FK_Bid_Tender_Id { get; private set; }
        public string FK_Bid_User_Id { get; private set; } = string.Empty;
        public int FK_Bid_Bidder_Id { get; private set; }

        // NAVIGATION PROPERTIES
        public Tender Tender { get; private set; } = null!;
        public AppUser User { get; private set; } = null!;
        public Bidder Bidder { get; private set; }

        public ICollection<Evaluation> Evaluations { get; private set; } = [];
        public ICollection<BidDocument> BidDocuments { get; private set; } = [];
    }
}