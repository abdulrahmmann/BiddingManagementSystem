namespace BiddingManagementSystem.Domain.Entities
{
    public class TenderDocument
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string FilePath { get; private set; } = string.Empty;

        public TenderDocument(string name, string filePath, int tenderId)
        {
            Name = name;
            FilePath = filePath;
            TenderId = tenderId;
        }

        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //
        public int TenderId { get; private set; }
        // public Tender Tender { get; private set; }
    }
}