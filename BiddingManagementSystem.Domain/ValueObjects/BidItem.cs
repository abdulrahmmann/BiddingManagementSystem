namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class BidItem
    {
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
