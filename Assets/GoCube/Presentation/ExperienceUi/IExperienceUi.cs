using System;

namespace GoCube.Presentation.ExperienceUi
{
    public interface IExperienceUi
    {
        event Action OnUiLoaded;
        void FillExperienceBar(int amount,  int experienceRequiredForNextLevel, float inSeconds);
        void NextLevelReached();
        void SetExperienceBarValue(int currentExperience, int nextLevelRequirement);
        void SetLevel(int currentLevel);
    }
}