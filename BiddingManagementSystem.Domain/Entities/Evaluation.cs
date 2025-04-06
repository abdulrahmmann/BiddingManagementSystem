using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Domain.Entities
{
    public class Evaluation
    {
        public int Id { get; private set; }

        public decimal TotalScore { get; private set; }

        public List<decimal> Scores { get; private set; } = [];

        public EvaluationCriteria Ev_Criteria { get; private set; } = null!;

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
        public int FK_Evaluation_Bid_Id { get; private set; }


        // NAVIGATION PROPERTIES
        public Bid Bid { get; private set; }
    }
}
