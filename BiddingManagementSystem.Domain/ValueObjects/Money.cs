namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; private set; }

        public string Currency { get; private set; }

        public Money() { }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
