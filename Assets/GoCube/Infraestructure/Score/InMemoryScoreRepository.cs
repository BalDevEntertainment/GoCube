using GoCube.Domain.ScoreEntity;

namespace GoCube.Infraestructure.Score {
    public class InMemoryScoreRepository : IScoreRepository {

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