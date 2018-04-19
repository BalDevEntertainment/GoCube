namespace GoCube.Domain.PlayerEntity
{
    public interface IPlayerLevelProgression
    {
        int GetExperienceRequirementForLevel(int level);
        int GetUnlockedEnemies(int currentLevel);
    }
}