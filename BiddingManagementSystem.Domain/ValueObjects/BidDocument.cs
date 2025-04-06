using BiddingManagementSystem.Domain.Entities;

namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class BidDocument
    {
        public int Id { get; set; }
        public string Name { get; private set; } = string.Empty;
        public string FilePath { get; private set; } = string.Empty;

        private BidDocument() { }

        public BidDocument(string name, string filePath)
        {
            Name = name;
            FilePath = filePath;
        }

        public int BidDocumentId { get; private set; }
        public Bid Bid { get; private set; }
    }
}
