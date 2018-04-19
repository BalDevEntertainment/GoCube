using GoCube.Domain.GameEntity;
using GoCube.Domain.ScoreEntity;
using GoCube.Presentation.ExperienceUi;

namespace GoCube.Domain.ExperienceEntity
{
    public class Experience
    {
        private readonly IExperienceUi _experienceUi;
        private readonly IGameEvents _gameEvents;
        private readonly ScoreService _score;
        private readonly ExperienceService _experienceService;
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
            _gameEvents.OnAddScoreToExperience += AddScoreToExperience;
            _experienceUi.OnUiLoaded += UiLoaded;
        }

        private void UiLoaded()
        {
            _experienceUi.UpdateExperienceBar(_experienceService.GetCurrentExperienceViewModel());
        }

        public void Destroy()
        {
            _score.ScoreChanged -= OnScoreChanged;
            _gameEvents.OnAddScoreToExperience -= AddScoreToExperience;
            _experienceUi.OnUiLoaded -= UiLoaded;
        }

        private void AddScoreToExperience()
        {
            _experienceUi.UpdateExperienceBar(_experienceService.GetCurrentExperienceViewModel());
            _experienceService.IncrementExperience(_gainedExperience);
            _experienceUi.FillExperienceBar(_experienceService.GetCurrentExperienceViewModel());
            _gainedExperience = 0;
        }

        private void OnScoreChanged(int currentScore)
        {
            _gainedExperience = currentScore;
        }
    }
}