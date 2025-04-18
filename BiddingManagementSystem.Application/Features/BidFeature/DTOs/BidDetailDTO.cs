using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Application.Features.BidFeature.DTOs
{
    public class BidDetailDTO
    {
        public int Id { get; set; }
        public string TechnicalProposal { get; set; } = string.Empty;
        public string FinancialProposal { get; set; } = string.Empty;
        public decimal TotalBidAmount { get; set; }
        public BidStatus Status { get; set; }
        public DateTime SubmittedAt { get; set; }

        public string TenderTitle { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string BidderName { get; set; } = string.Empty;

        public List<BidItemDTO> Items { get; set; } = [];
    }
}
