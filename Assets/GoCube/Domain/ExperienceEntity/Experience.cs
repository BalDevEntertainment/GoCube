using GoCube.Domain.GameEntity;
using GoCube.Domain.ScoreEntity;
using GoCube.Presentation.ExperienceUi;

namespace GoCube.Domain.ExperienceEntity
{
    public class Experience
    {
        private readonly float _nextLevel;
        private IExperienceUi _experienceUi;
        private readonly ScoreService _score;
        private IGameEvents _gameEvents;
        private int _currentExperience;

        public Experience(float nextLevel, IExperienceUi experienceUi, ScoreService score,
            IGameEvents gameEvents)
        {
            _nextLevel = nextLevel;
            _experienceUi = experienceUi;
            _score = score;
            _gameEvents = gameEvents;
            Init();
        }

        private void Init()
        {
            _score.ScoreChanged += OnScoreChanged;
            _gameEvents.OnAddScoreToExperience += AddScoreToExperience;
        }

        public void Destroy()
        {
            _score.ScoreChanged -= OnScoreChanged;
            _gameEvents.OnAddScoreToExperience -= AddScoreToExperience;
        }

        private void AddScoreToExperience(float inSeconds)
        {
            _experienceUi.FillExperienceBar(_currentExperience, inSeconds);
        }

        private void OnScoreChanged(int currentScore)
        {
            _currentExperience = currentScore;
        }
    }
}