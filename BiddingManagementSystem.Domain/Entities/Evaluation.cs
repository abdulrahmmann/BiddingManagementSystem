using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Domain.Entities
{
    public class Evaluation
    {
        public int Id { get; private set; }

        public decimal TotalScore { get; private set; }

        public List<decimal> Scores { get; private set; } = [];


        private readonly List<EvaluationCriteria> _evaluationCriterias = []; // VALUE OBJECT
        public IReadOnlyCollection<EvaluationCriteria> EvaluationCriterias => _evaluationCriterias.AsReadOnly();

        public DateTime EvaluationDate { get; private set; }

        public Evaluation() { }
        public Evaluation(List<decimal> Scores)
        {
            TotalScore = CalculateTotalScore(Scores);
            EvaluationDate = DateTime.UtcNow;
            this.Scores = Scores;
        }

        public decimal CalculateTotalScore(List<decimal> scores)
        {
            decimal total = 0;
            foreach (var score in scores)
                total += score;

            return total / scores.Count;
        }

        // ************************************************************* //
        // ------------------------> RELATIONS <------------------------ //
        // ************************************************************* //

        // FOREIGN KEYS
        public int BidId { get; private set; }


        // NAVIGATION PROPERTIES
        public Bid Bid { get; private set; }
    }
}
