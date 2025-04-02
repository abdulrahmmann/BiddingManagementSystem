using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Domain.Entities
{
    public class Bidder
    {
        public int Id { get; set; }

        public Company Company { get; private set; }

        private Bidder() { }

        public Bidder(Company company)
        {
            Company = company;
        }
        public ICollection<Bid> Bids { get; private set; } = [];

        public void PlaceBid(Bid bid)
        {
            Bids.Add(bid);
        }
    }
}
