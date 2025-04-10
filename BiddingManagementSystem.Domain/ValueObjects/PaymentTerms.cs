namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class PaymentTerms
    {
        public decimal AdvancePercentage { get; private set; }
        public decimal MilestonePercentage { get; private set; }
        public decimal FinalApprovalPercentage { get; private set; }
        public string PaymentMethod { get; private set; }
        public int PenaltyOfDelays { get; private set; }

        public PaymentTerms() { }

        public PaymentTerms(decimal advancePercentage, decimal milestonePercentage, decimal finalApprovalPercentage, string paymentMethod, int penaltyTerms)
        {
            if (advancePercentage + milestonePercentage + finalApprovalPercentage != 100)
                throw new ArgumentException("Total payment percentage must be equal 100%.");

            AdvancePercentage = advancePercentage;
            MilestonePercentage = milestonePercentage;
            FinalApprovalPercentage = finalApprovalPercentage;
            PaymentMethod = paymentMethod;
            PenaltyOfDelays = penaltyTerms;
        }

    }
}
