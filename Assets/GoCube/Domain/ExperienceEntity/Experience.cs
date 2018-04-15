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
        private readonly ExperienceService _experienceService;
        private IGameEvents _gameEvents;
        private int _gainedExperience;

        public Experience(float nextLevel, IExperienceUi experienceUi, ScoreService score,
            ExperienceService experienceService, IGameEvents gameEvents)
        {
            _nextLevel = nextLevel;
            _experienceUi = experienceUi;
            _score = score;
            _experienceService = experienceService;
            _gameEvents = gameEvents;
            Init();
        }

        private void Init()
        {
            _score.ScoreChanged += OnScoreChanged;
            _experienceService.OnNextLevelReached += NextLevelReached;
            _gameEvents.OnAddScoreToExperience += SaveExperienceGained;
        }

        public void Destroy()
        {
            _score.ScoreChanged -= OnScoreChanged;
            _experienceService.OnNextLevelReached -= NextLevelReached;
            _gameEvents.OnAddScoreToExperience -= SaveExperienceGained;
        }

        private void SaveExperienceGained(float inSeconds)
        {
            _experienceService.IncrementExperience(_gainedExperience);
            _experienceUi.FillExperienceBar(_experienceService.CurrentExperience() + _gainedExperience, inSeconds);
            _gainedExperience = 0;
        }

        private void OnScoreChanged(int currentScore)
        {
            _gainedExperience = currentScore;
        }

        private void NextLevelReached()
        {
            _experienceUi.NextLevelReached();
        }
    }
}