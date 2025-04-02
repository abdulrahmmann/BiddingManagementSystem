namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class EligibilityCriteria
    {
        public bool RequiresBusinessLicense { get; private set; }

        public int MinimumExperienceYears { get; private set; }

        public bool FinancialStabilityRequirement { get; private set; }

        public bool IndustryCompliance { get; private set; }

        public EligibilityCriteria() { }

        public EligibilityCriteria(bool requiresBusinessLicense, int minimumExperienceYears,
            bool financialStabilityRequirement, bool industryCompliance)
        {
            RequiresBusinessLicense = requiresBusinessLicense;
            MinimumExperienceYears = minimumExperienceYears;
            FinancialStabilityRequirement = financialStabilityRequirement;
            IndustryCompliance = industryCompliance;
        }
    }
}
