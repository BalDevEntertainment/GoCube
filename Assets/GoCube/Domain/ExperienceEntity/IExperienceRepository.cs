namespace GoCube.Domain.ExperienceEntity
{
    public interface IExperienceRepository
    {
        int Add(int quantity);
        void Clear();
        int CurrentExperience();
    }
}