namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class Company
    {
        public string CompanyName { get; private set; } = string.Empty;

        public string RegistrationNumber { get; private set; } = string.Empty;

        public string Address { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;

        public string Phone { get; private set; } = string.Empty;

        private Company() { }

        public Company(string companyName, string registrationNumber, string address, string email, string phone)
        {
            CompanyName = companyName;
            RegistrationNumber = registrationNumber;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
