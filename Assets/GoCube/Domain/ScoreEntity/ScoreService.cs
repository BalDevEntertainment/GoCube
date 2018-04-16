using System;

namespace GoCube.Domain.ScoreEntity {
    
    public class ScoreService {
        
        private readonly IScoreRepository scoreRepository;
        private readonly MaxScoreRepository maxScoreRepository;
        private readonly LeaderBoardScoreService leaderboardScoreService;

        public event Action<int> ScoreChanged = delegate {  };
        public event Action<int> MaxScoreReached = delegate {  };

        public ScoreService(IScoreRepository scoreRepository, MaxScoreRepository maxScoreRepository, LeaderBoardScoreService leaderboardScoreService) {
            this.scoreRepository = scoreRepository;
            this.leaderboardScoreService = leaderboardScoreService;
            this.maxScoreRepository = maxScoreRepository;
        }
        
        public void IncrementScore(int quantity) {
            var actualScore = scoreRepository.Add(quantity);
            ScoreChanged(actualScore);
            var maxScore = maxScoreRepository.Find();
            if (actualScore > maxScore) {
                maxScoreRepository.Update(actualScore);
                MaxScoreReached(actualScore);
                leaderboardScoreService.UpdateLeaderBoard(actualScore);
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