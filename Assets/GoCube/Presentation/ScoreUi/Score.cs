using GoCube.Domain.GameEntity;
using GoCube.Domain.Score;

namespace GoCube.Presentation.ScoreUi
{
    public class Score
    {
        private readonly IScoreUi _scoreUi;
        private readonly ScoreService _scoreService;
        private readonly IGameEvents _gameEvents;

        public Score(IScoreUi scoreUi, ScoreService scoreService, IGameEvents gameEvents)
        {
            _scoreUi = scoreUi;
            _scoreService = scoreService;
            _gameEvents = gameEvents;
            Init();
        }

        private void Init()
        {
            _gameEvents.OnGameStart += _scoreUi.Show;
            _scoreService.MaxScoreReached += _scoreUi.OnMaxScoreChanged;
            _scoreService.ScoreChanged += _scoreUi.OnScoreChanged;
            _scoreUi.Hide();
        }

        public void Destroy()
        {
            _gameEvents.OnGameStart -= _scoreUi.Show;
            _scoreService.MaxScoreReached -= _scoreUi.OnMaxScoreChanged;
            _scoreService.ScoreChanged -= _scoreUi.OnScoreChanged;
            _scoreService.ClearScore();
        }
    }
}