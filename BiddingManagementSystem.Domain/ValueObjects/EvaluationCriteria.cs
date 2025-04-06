namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class EvaluationCriteria
    {
        public string CriterionName { get; private set; }
        public int Weight { get; private set; }

        public EvaluationCriteria() { }
        public EvaluationCriteria(string criterionName, int weight)
        {
            if (string.IsNullOrWhiteSpace(criterionName))
                throw new ArgumentException("Criterion name cannot be empty.");

            if (weight < 0 || weight > 100)
                throw new ArgumentException("Weight must be between 0 and 100.");

            CriterionName = criterionName;
            Weight = weight;
        }
    }
}
