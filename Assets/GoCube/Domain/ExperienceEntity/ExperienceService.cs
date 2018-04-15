using System;
using GoCube.Domain.PlayerEntity;

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

        public void IncrementExperience(int quantity)
        {
            var previousExperience = _experienceRepository.CurrentExperience();
            var actualExperience = _experienceRepository.Add(quantity);
            if (HasReachedNewLevel(previousExperience, actualExperience))
            {
                OnNextLevelReached();
            }
        }

        private bool HasReachedNewLevel(int previousExperience, int actualExperience)
        {
            return _playerLevelProgression.GetLevelForExp(previousExperience) <
                   _playerLevelProgression.GetLevelForExp(actualExperience);
        }

        public int CurrentExperience()
        {
            return _experienceRepository.CurrentExperience();
        }

        public int NextLevelRequirement()
        {
            return _playerLevelProgression.GetExperienceRequirementForLevel(
                _playerLevelProgression.GetLevelForExp(_experienceRepository.CurrentExperience()));
        }

        public int CurrentLevel()
        {
            return _playerLevelProgression.GetLevelForExp(_experienceRepository.CurrentExperience());
        }
    }
}