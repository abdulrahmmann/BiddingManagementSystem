using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Domain.Entities
{
    public class Tender
    {
        public int Id { get; private set; }

        public int ReferenceNumber { get; private set; }

        public string Title { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public string IssuedBy { get; private set; } = string.Empty;

        public DateTime Deadline { get; private set; }

        public DateTime IssueDate { get; private set; }

        public DateTime ClosingDate { get; private set; }

        public string Email { get; private set; } = string.Empty;

        public TenderType Type { get; private set; } // ENUM

        public TenderIndustry Industry { get; private set; } // ENUM

        public Money BudgetRange { get; private set; } = null!; // VALUE OBJECT

        public Address Address { get; private set; } = null!;// VALUE OBJECT

        private readonly List<EligibilityCriteria> _eligibilityCriteria = [];
        public IReadOnlyCollection<EligibilityCriteria> EligibilityCriteria => _eligibilityCriteria.AsReadOnly();

        public readonly List<TenderDocument> _documents = [];
        public IReadOnlyCollection<TenderDocument> Documents => _documents.AsReadOnly();

        public PaymentTerms PaymentTerms { get; private set; } = null!; // VALUE OBJECT

        public Tender(int referenceNumber, string title, string description, string issuedBy, DateTime deadline,
            DateTime issueDate, DateTime closingDate, string email, TenderType type, TenderIndustry industry,
            Money budgetRange, int createdById, User User)
        {
            ReferenceNumber = referenceNumber;
            Title = title;
            Description = description;
            IssuedBy = issuedBy;
            Deadline = deadline;
            IssueDate = issueDate;
            ClosingDate = closingDate;
            Email = email;
            Type = type;
            Industry = industry;
            BudgetRange = budgetRange;
            CreatedById = createdById;
            this.User = User;
        }

        public void AddDocument(TenderDocument document)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            _documents.Add(document);
        }

        public void AddEligibilityCriteria(EligibilityCriteria criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));
            _eligibilityCriteria.Add(criteria);
        }

        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //

        // FOREIGN KEYS
        public int CreatedById { get; private set; }


        // NAVIGATION PROPERTIES
        public User User { get; private set; } = null!;
        public ICollection<Bid> Bids { get; private set; } = [];
    }
}
