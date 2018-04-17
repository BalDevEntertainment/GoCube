namespace GoCube.Presentation.ExperienceUi
{
    public interface IExperienceUi
    {
        void FillExperienceBar(int amount, float inSeconds);
        void NextLevelReached();
        void SetExperienceBarValue(int value);
        void SetLevel(int currentLevel);
    }
}