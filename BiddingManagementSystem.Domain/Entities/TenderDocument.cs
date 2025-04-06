namespace BiddingManagementSystem.Domain.Entities
{
    public class TenderDocument
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        public string FilePath { get; private set; } = string.Empty;

        private TenderDocument() { }
        public TenderDocument(string name, string filePath, int tenderId)
        {
            Name = name;
            FilePath = filePath;
        }

        public int TenderDocumentId { get; private set; }
        public Tender Tender { get; private set; }
    }
}