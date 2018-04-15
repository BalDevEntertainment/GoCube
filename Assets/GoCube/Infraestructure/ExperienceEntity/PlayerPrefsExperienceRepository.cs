using GoCube.Domain.ExperienceEntity;
using UnityEngine;

namespace GoCube.Infraestructure.ExperienceEntity
{
    public class PlayerPrefsExperienceRepository : IExperienceRepository
    {
        private const string ExperienceKey = "experience";
        private int _currentExperience;

        public PlayerPrefsExperienceRepository()
        {
            _currentExperience = PlayerPrefs.HasKey(ExperienceKey) ? PlayerPrefs.GetInt(ExperienceKey) : 0;
        }

        public int Add(int actualScore)
        {
            _currentExperience += actualScore;
            PlayerPrefs.SetInt(ExperienceKey, _currentExperience);
            return _currentExperience;
        }

        public void Clear() {
            PlayerPrefs.DeleteKey(ExperienceKey);
            _currentExperience = 0;
        }

        public int CurrentExperience()
        {
            return _currentExperience;
        }
    }
}