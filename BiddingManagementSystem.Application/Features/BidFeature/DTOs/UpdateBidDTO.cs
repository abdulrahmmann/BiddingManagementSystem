using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Application.Features.BidFeature.DTOs
{
    public class UpdateBidDTO
    {
        public int Id { get; set; }

        public string TechnicalProposal { get; set; } = string.Empty;
        public string FinancialProposal { get; set; } = string.Empty;
        public decimal TotalBidAmount { get; set; }
        public BidStatus Status { get; set; }

        public List<BidItemDTO> Items { get; set; } = [];
    }
}
