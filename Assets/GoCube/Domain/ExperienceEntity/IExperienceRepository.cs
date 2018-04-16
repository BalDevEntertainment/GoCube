namespace GoCube.Domain.ExperienceEntity
{
    public interface IExperienceRepository
    {
        int Add(int quantity);
        int CurrentExperience();
    }
}