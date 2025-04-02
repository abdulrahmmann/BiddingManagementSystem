namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class Address
    {
        public string Country { get; private set; } = string.Empty;

        public string City { get; private set; } = string.Empty;

        public string Street { get; private set; } = string.Empty;

        public string ZipCode { get; private set; } = string.Empty;

        public Address() { }

        public Address(string country, string city, string street, string zipCode)
        {
            Country = country;
            City = city;
            Street = street;
            ZipCode = zipCode;
        }
    }
}