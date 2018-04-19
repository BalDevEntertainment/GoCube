namespace GoCube.Domain.ExperienceEntity
{
    public interface IExperienceRepository
    {
        int CurrentExperience();
        int CurrentLevel();
        void SetLevel(int level);
        void SetExperience(int value);
    }
}