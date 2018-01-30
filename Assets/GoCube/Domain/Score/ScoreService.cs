using System;

namespace Assets.GoCube.Domain.Score {
    
    public class ScoreService {
        
        private readonly ScoreRepository scoreRepository;
        private readonly MaxScoreRepository maxScoreRepository;

        public event Action<int> ScoreChanged = delegate {  };
        public event Action<int> MaxScoreReached = delegate {  };

        public ScoreService(ScoreRepository scoreRepository, MaxScoreRepository maxScoreRepository) {
            this.scoreRepository = scoreRepository;
            this.maxScoreRepository = maxScoreRepository;
        }
        
        public void IncrementScore(int quantity) {
            var actualScore = scoreRepository.Add(quantity);
            ScoreChanged(actualScore);
            if (actualScore > maxScoreRepository.Find()) {
                maxScoreRepository.Update(actualScore);
                MaxScoreReached(actualScore);
            }
                
        }
        
    }
}