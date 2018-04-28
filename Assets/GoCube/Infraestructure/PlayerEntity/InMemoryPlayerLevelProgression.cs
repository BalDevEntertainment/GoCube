using System.Collections.Generic;
using GoCube.Domain.PlayerEntity;

namespace GoCube.Infraestructure.PlayerEntity
{
    public class InMemoryPlayerLevelProgression : IPlayerLevelProgression
    {
        private readonly Dictionary<int, int> _experienceRequiredForEachLevel =
            new Dictionary<int, int>();

        public InMemoryPlayerLevelProgression()
        {
            for (int i = 1; i < 100; i++)
            {
                _experienceRequiredForEachLevel.Add(i,50);
            }
        }

        public int GetExperienceRequirementForLevel(int level)
        {
            return _experienceRequiredForEachLevel.ContainsKey(level) ?
                _experienceRequiredForEachLevel[level] :
                int.MaxValue;
        }

        public int GetUnlockedEnemies(int currentLevel)
        {
            return currentLevel >= 3 ? 1 : 0;
        }
    }
}