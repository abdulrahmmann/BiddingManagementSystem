namespace BiddingManagementSystem.Application.Features.BidFeature.DTOs
{
    public class BidItemDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
