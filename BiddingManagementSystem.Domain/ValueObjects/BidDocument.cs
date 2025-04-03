namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class BidDocument
    {
        public string Name { get; private set; } = string.Empty;
        public string FilePath { get; private set; } = string.Empty;

        private BidDocument() { }

        public BidDocument(string name, string filePath)
        {
            Name = name;
            FilePath = filePath;
        }
    }
}
