namespace BiddingManagementSystem.Domain.Entities
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

        public int FK_Bid_Document_Id { get; private set; }
        public Bid Bid { get; private set; }
    }
}
