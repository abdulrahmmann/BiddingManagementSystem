namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class TenderDocument
    {
        public string Name { get; private set; } = string.Empty;

        public string FilePath { get; private set; } = string.Empty;

        private TenderDocument() { }
        public TenderDocument(string name, string filePath, int tenderId)
        {
            Name = name;
            FilePath = filePath;
        }
    }
}