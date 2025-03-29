using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Domain.Entities
{
    public class Tender
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string IssuedBy { get; private set; }
        public DateTime Deadline { get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ClosingDate { get; private set; }
        public TenderType TenderType { get; private set; }
        public TenderCategory Category { get; private set; }
        public decimal Budget { get; private set; }
        public string ContactEmail { get; private set; }
        public string ContactPhone { get; private set; }

        public List<TenderDocument> Documents { get; private set; } = new List<TenderDocument>();
        public List<EligibilityCriteria> EligibilityCriteria { get; private set; } = new List<EligibilityCriteria>();
        public List<EvaluationCriteria> EvaluationCriteria { get; private set; } = new List<EvaluationCriteria>();

        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //
        public int CreatedById { get; private set; } // FOREIGN KEY
        public User CreatedBy { get; private set; }

        public ICollection<Bid> Bids { get; private set; } = new List<Bid>();
    }
}