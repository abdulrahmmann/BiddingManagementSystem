namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public Money() { }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
