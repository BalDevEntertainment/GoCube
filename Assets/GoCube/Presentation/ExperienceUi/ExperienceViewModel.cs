namespace GoCube.Presentation.ExperienceUi
{
    public class ExperienceViewModel
    {
        public int CurrentExperience { get; private set; }
        public int NextLevelRequirement { get; private set; }
        public int CurrentLevel { get; private set; }
        public int EnemiesUnlocked { get; private set; }

        public ExperienceViewModel(int currentExperience, int nextLevelRequirement,
            int currentLevel, int enemiesUnlocked)
        {
            CurrentExperience = currentExperience;
            NextLevelRequirement = nextLevelRequirement;
            CurrentLevel = currentLevel;
            EnemiesUnlocked = enemiesUnlocked;
        }

    }
}