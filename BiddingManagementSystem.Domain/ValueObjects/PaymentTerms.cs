using BiddingManagementSystem.Domain.Enums;

namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class PaymentTerms
    {
        public decimal AdvancePercentage { get; private set; }
        public decimal MilestonePercentage { get; private set; }
        public decimal FinalApprovalPercentage { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public string PenaltyOfDelays { get; private set; } = string.Empty;

        public PaymentTerms() { }

        public PaymentTerms(decimal advancePercentage, decimal milestonePercentage, decimal finalApprovalPercentage, PaymentMethod paymentMethod, string penaltyTerms)
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
