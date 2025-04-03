using BiddingManagementSystem.Domain.Entities;

namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class BidDocument
    {
        public string Name { get; private set; } = string.Empty;

        public string FilePath { get; private set; } = string.Empty;

        public BidDocument(string name, string filePath, int bidId)
        {
            Name = name;
            FilePath = filePath;
            BidId = bidId;
        }


        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //

        public int BidId { get; private set; }
        public Bid Bid { get; private set; }
    }
}
