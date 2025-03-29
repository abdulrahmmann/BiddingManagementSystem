namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class BidDocument
    {
        public string Name { get; private set; }
        public string FilePath { get; private set; }
        public string DocumentType { get; private set; }
        public DateTime UploadDate { get; private set; }
        public string? Notes { get; private set; }
    }
}
