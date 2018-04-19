using System;
using GoCube.Domain.PlayerEntity;
using GoCube.Presentation.ExperienceUi;

namespace GoCube.Domain.ExperienceEntity
{
    public class ExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IPlayerLevelProgression _playerLevelProgression;
        public event Action OnNextLevelReached = delegate { };

        public ExperienceService(IPlayerLevelProgression playerLevelProgression,
            IExperienceRepository experienceRepository)
        {
            _playerLevelProgression = playerLevelProgression;
            _experienceRepository = experienceRepository;
        }

        public ExperienceViewModel IncrementExperience(int quantity)
        {
            var previousExperience = _experienceRepository.CurrentExperience();
            var actualExperience = previousExperience + quantity;
            if (HasReachedNewLevel(actualExperience))
            {
                LevelUp(actualExperience);
            }
            else
            {
                _experienceRepository.SetExperience(actualExperience);
            }

            return BuildCurrentExperienceViewModel();
        }

        public ExperienceViewModel GetCurrentExperienceViewModel()
        {
            return BuildCurrentExperienceViewModel();
        }

        private ExperienceViewModel BuildCurrentExperienceViewModel()
        {
            return new ExperienceViewModel(_experienceRepository.CurrentExperience(),
                _playerLevelProgression.GetExperienceRequirementForLevel(_experienceRepository.CurrentLevel()),
                _experienceRepository.CurrentLevel(),
                _playerLevelProgression.GetUnlockedEnemies(_experienceRepository.CurrentLevel()));
        }

        private void LevelUp(int actualExperience)
        {
            var neededExperience =
                _playerLevelProgression.GetExperienceRequirementForLevel(
                    _experienceRepository.CurrentLevel());
            actualExperience = actualExperience - neededExperience;
            _experienceRepository.SetLevel(_experienceRepository.CurrentLevel() + 1);
            _experienceRepository.SetExperience(actualExperience);
            OnNextLevelReached();
        }

        private bool HasReachedNewLevel(int actualExperience)
        {
            return actualExperience >=
                _playerLevelProgression.GetExperienceRequirementForLevel(_experienceRepository.CurrentLevel());
        }
    }
}