namespace BiddingManagementSystem.Domain.Entities
{
    public class Bidder
    {
        public int Id { get; set; }

        public string CompanyName { get; private set; } = string.Empty;

        public string RegistrationNumber { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;

        public string Phone { get; private set; } = string.Empty;

        public string Address { get; private set; } = string.Empty;

        public int FK_Bidder_Tender_Id { get; private set; }

        public Tender Tender { get; private set; } = null!;

        private Bidder() { }

        public Bidder(string companyName, string registrationNumber, string email, string phone, string address)
        {
            CompanyName = companyName;
            RegistrationNumber = registrationNumber;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public ICollection<Bid> Bids { get; private set; } = [];

        public void PlaceBid(Bid bid)
        {
            Bids.Add(bid);
        }
    }
}
