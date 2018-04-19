using GoCube.Domain.ExperienceEntity;
using UnityEngine;

namespace GoCube.Infraestructure.ExperienceEntity
{
    public class PlayerPrefsExperienceRepository : IExperienceRepository
    {
        private const string ExperienceKey = "experience";
        private const string LevelKey = "level";
        private int _currentExperience;
        private int _currentLevel;

        public PlayerPrefsExperienceRepository()
        {
            if (!PlayerPrefs.HasKey(LevelKey))
            {
                PlayerPrefs.SetInt(LevelKey, 1);
                PlayerPrefs.SetInt(ExperienceKey, 0);
            }
            _currentExperience = PlayerPrefs.HasKey(ExperienceKey) ? PlayerPrefs.GetInt(ExperienceKey) : 0;
            _currentLevel = PlayerPrefs.HasKey(LevelKey) ? PlayerPrefs.GetInt(LevelKey) : 1;
        }

        public int CurrentExperience()
        {
            return _currentExperience;
        }

        public int CurrentLevel()
        {
            return _currentLevel;
        }

        public void SetLevel(int level)
        {
            _currentLevel = level;
            PlayerPrefs.SetInt(LevelKey, level);
        }

        public void SetExperience(int value)
        {
            PlayerPrefs.SetInt(ExperienceKey, value);
            _currentExperience = value;
        }
    }
}