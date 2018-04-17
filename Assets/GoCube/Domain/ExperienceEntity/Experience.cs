using GoCube.Domain.GameEntity;
using GoCube.Domain.ScoreEntity;
using GoCube.Presentation.ExperienceUi;

namespace GoCube.Domain.ExperienceEntity
{
    public class Experience
    {
        private IExperienceUi _experienceUi;
        private readonly ScoreService _score;
        private readonly ExperienceService _experienceService;
        private IGameEvents _gameEvents;
        private int _gainedExperience;

        public Experience(IExperienceUi experienceUi, ScoreService score,
            ExperienceService experienceService, IGameEvents gameEvents)
        {
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
            _experienceUi.OnUiLoaded += UiLoaded;
        }

        private void UiLoaded()
        {
            _experienceUi.SetExperienceBarValue(_experienceService.CurrentExperience(),
                _experienceService.NextLevelRequirement());
            _experienceUi.SetLevel(_experienceService.CurrentLevel());
        }

        public void Destroy()
        {
            _score.ScoreChanged -= OnScoreChanged;
            _experienceService.OnNextLevelReached -= NextLevelReached;
            _gameEvents.OnAddScoreToExperience -= SaveExperienceGained;
            _experienceUi.OnUiLoaded -= UiLoaded;
        }

        private void SaveExperienceGained(float inSeconds)
        {
            _experienceUi.SetLevel(_experienceService.CurrentLevel());
            _experienceService.IncrementExperience(_gainedExperience);
            _experienceUi.FillExperienceBar(_gainedExperience, _experienceService.NextLevelRequirement(), inSeconds);
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

        public int NextLevelRequirement()
        {
            return _experienceService.NextLevelRequirement();
        }
    }
}