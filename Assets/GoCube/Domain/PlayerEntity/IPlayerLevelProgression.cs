namespace GoCube.Domain.PlayerEntity
{
    public interface IPlayerLevelProgression
    {
        int GetLevelForExp(int previousExperience);
        int GetExperienceRequirementForLevel(int level);
    }
}