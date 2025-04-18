using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Application.Features.BidFeature.DTOs
{
    public class CreateBidDTO
    {
        public string TechnicalProposal { get; set; } = string.Empty;
        public string FinancialProposal { get; set; } = string.Empty;
        public decimal TotalBidAmount { get; set; }
        public BidStatus Status { get; set; }
        public DateTime SubmittedAt { get; set; }

        // Foreign Keys
        public int TenderId { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public int BidderId { get; set; }

        public List<BidItemDTO> Items { get; set; } = [];
    }
}
