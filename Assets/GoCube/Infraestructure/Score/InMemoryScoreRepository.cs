using GoCube.Domain.Score;

namespace GoCube.Infraestructure.Score {
    public class InMemoryScoreRepository : ScoreRepository {

        private int _score;
        
        public int Add(int quantity) {
            _score += quantity;
            return _score;
        }

        public void Clear() {
            _score = 0;
        }
    }
}