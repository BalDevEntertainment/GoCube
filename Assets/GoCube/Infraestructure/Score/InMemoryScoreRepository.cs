using Assets.GoCube.Domain.Score;

namespace Assets.GoCube.Infraestructure.Score {
    public class InMemoryScoreRepository : ScoreRepository {

        private int score;
        
        public int Add(int quantity) {
            score += quantity;
            return score;
        }

        public void Clear() {
            score = 0;
        }
    }
}