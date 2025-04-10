namespace BiddingManagementSystem.Application.Features.TenderFeature.DTOs
{
    public class CreateTenderDTO
    {
        public int ReferenceNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IssuedBy { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;

        public decimal BudgetRange_Amount { get; set; }
        public string BudgetRange_Currency { get; set; } = string.Empty;

        public string Address_Country { get; set; } = string.Empty;
        public string Address_City { get; set; } = string.Empty;
        public string Address_Street { get; set; } = string.Empty;
        public string Address_ZipCode { get; set; } = string.Empty;

        public decimal PaymentTerms_AdvancePercentage { get; set; }
        public decimal PaymentTerms_MilestonePercentage { get; set; }
        public decimal PaymentTerms_FinalApprovalPercentage { get; set; }
        public string PaymentTerms_PaymentMethod { get; set; } = string.Empty;
        public int PaymentTerms_PenaltyOfDelays { get; set; }

        public bool ElgC_FinStabReq { get; set; }
        public bool ElgC_IndComp { get; set; }
        public bool ElgC_ReqBizLicense { get; set; }
        public int ElgC_MinExpYears { get; set; }
    }
}