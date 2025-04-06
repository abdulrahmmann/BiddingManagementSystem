﻿using BiddingManagementSystem.Domain.Enums;
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

        public EligibilityCriteria ElgCriteria { get; private set; } = null!; // VALUE OBJECT

        public PaymentTerms PaymentTerms { get; private set; } = null!; // VALUE OBJECT

        public Tender() { }

        public Tender(int referenceNumber, string title, string description, string issuedBy, DateTime deadline,
            DateTime issueDate, DateTime closingDate, string email, TenderType type, TenderIndustry industry,
            Money budgetRange, Address Address, EligibilityCriteria Criteria, string createdById)
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
            this.Address = Address;
            this.ElgCriteria = Criteria;
            FK_Tender_User_Id = createdById;
        }

        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //

        // FOREIGN KEYS
        public string FK_Tender_User_Id { get; private set; } = string.Empty;

        // NAVIGATION PROPERTIES
        public AppUser User { get; private set; } = null!;
        public ICollection<Bid> Bids { get; private set; } = [];
        public ICollection<Bidder> Bidders { get; private set; } = [];
        public ICollection<TenderDocument> TenderDocument { get; private set; } = [];
    }
}
