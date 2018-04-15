using System;

namespace GoCube.Domain.ScoreEntity {
    
    public class ScoreService {
        
        private readonly IScoreRepository scoreRepository;
        private readonly MaxScoreRepository maxScoreRepository;

        public event Action<int> ScoreChanged = delegate {  };
        public event Action<int> MaxScoreReached = delegate {  };

        public ScoreService(IScoreRepository scoreRepository, MaxScoreRepository maxScoreRepository) {
            this.scoreRepository = scoreRepository;
            this.maxScoreRepository = maxScoreRepository;
        }
        
        public void IncrementScore(int quantity) {
            var actualScore = scoreRepository.Add(quantity);
            ScoreChanged(actualScore);
            var maxScore = maxScoreRepository.Find();
            if (actualScore > maxScore) {
                maxScoreRepository.Update(actualScore);
                MaxScoreReached(actualScore);
            }
        }

        public void ClearScore() {
            scoreRepository.Clear();
        }

        public int FindMaxScore() {
            return maxScoreRepository.Find();
        }
    }
}