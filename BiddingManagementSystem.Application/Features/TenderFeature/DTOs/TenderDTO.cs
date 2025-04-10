namespace BiddingManagementSystem.Application.Features.TenderFeature.DTOs
{
    public class TenderDTO
    {
        public int ReferenceNumber { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string IssuedBy { get; private set; } = string.Empty;
        public DateTime Deadline { get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ClosingDate { get; private set; }
        public string Type { get; private set; } = string.Empty;
        public string Industry { get; private set; } = string.Empty;

        public string BudgetRange_Amount { get; private set; } = string.Empty;
        public string BudgetRange_Currency { get; private set; } = string.Empty;

        public string Address_Country { get; private set; } = string.Empty;
        public string Address_City { get; private set; } = string.Empty;
        public string Address_Street { get; private set; } = string.Empty;
        public string Address_ZipCode { get; private set; } = string.Empty;

        public string PaymentTerms_AdvancePercentage { get; private set; } = string.Empty;
        public string PaymentTerms_MilestonePercentage { get; private set; } = string.Empty;
        public string PaymentTerms_FinalApprovalPercentage { get; private set; } = string.Empty;
        public string PaymentTerms_PaymentMethod { get; private set; } = string.Empty;
        public string PaymentTerms_PenaltyOfDelays { get; private set; } = string.Empty;
    }
}