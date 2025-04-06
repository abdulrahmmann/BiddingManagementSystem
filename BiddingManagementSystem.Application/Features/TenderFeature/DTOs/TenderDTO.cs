using BiddingManagementSystem.Domain.Enums;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Application.Features.TenderFeature.DTOs
{
    public class TenderDTO
    {
        public int ReferenceNumber { get; private set; }

        public string Title { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public string IssuedBy { get; private set; } = string.Empty;

        public DateTime Deadline { get; private set; }

        public DateTime IssueDate { get; private set; }

        public DateTime ClosingDate { get; private set; }

        public TenderType Type { get; private set; }

        public TenderIndustry Industry { get; private set; }

        public Money BudgetRange { get; private set; } = null!;

        public Address Address { get; private set; } = null!;
    }
}
