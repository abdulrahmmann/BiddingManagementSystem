namespace BiddingManagementSystem.Application.Features.TenderFeature.DTOs
{
    public class UpdateTenderDTO
    {
        public int ReferenceNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IssuedBy { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
    }
}
