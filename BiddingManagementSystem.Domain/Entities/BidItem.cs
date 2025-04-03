namespace BiddingManagementSystem.Domain.Entities
{
    public class BidItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        public int BidId { get; private set; }
        public Bid Bid { get; private set; }

        private BidItem() { }

        internal BidItem(string description, int quantity, decimal unitPrice)
        {
            Description = description;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
