using System;
using GoCube.Domain.Score;

namespace GoCube.Domain.ScoreEntity {
    
    public class ScoreService {
        
        private readonly IScoreRepository _scoreRepository;
        private readonly MaxScoreRepository _maxScoreRepository;
        private readonly LeaderBoardScoreService _leaderboardScoreService;

        public event Action<int> ScoreChanged = delegate {  };
        public event Action<int> MaxScoreReached = delegate {  };

        public ScoreService(IScoreRepository scoreRepository, MaxScoreRepository maxScoreRepository,
            LeaderBoardScoreService leaderboardScoreService) {
            _scoreRepository = scoreRepository;
            _leaderboardScoreService = leaderboardScoreService;
            _maxScoreRepository = maxScoreRepository;
        }
        
        public void IncrementScore(int quantity) {
            var actualScore = _scoreRepository.Add(quantity);
            ScoreChanged(actualScore);
            var maxScore = _maxScoreRepository.Find();
            if (actualScore > maxScore) {
                _maxScoreRepository.Update(actualScore);
                MaxScoreReached(actualScore);
                _leaderboardScoreService.UpdateLeaderBoard(actualScore);
            }
        }

        public void ClearScore() {
            _scoreRepository.Clear();
        }

        public int FindMaxScore() {
            return _maxScoreRepository.Find();
        }
    }
}