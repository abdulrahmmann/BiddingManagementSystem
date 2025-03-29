namespace BiddingManagementSystem.Domain.ValueObjects
{
    public class EvaluationCriteria
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Weight { get; private set; }
    }
}
