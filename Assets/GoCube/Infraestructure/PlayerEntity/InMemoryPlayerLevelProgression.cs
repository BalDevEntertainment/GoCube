using System.Collections.Generic;
using GoCube.Domain.PlayerEntity;

namespace GoCube.Infraestructure.PlayerEntity
{
    public class InMemoryPlayerLevelProgression : IPlayerLevelProgression
    {
        private readonly Dictionary<int, int> _experienceRequiredForNextLevel = new Dictionary<int, int>
        {
            {1,0}, {2,100}, {3,300}, {4,800}, {5,1500}
        };

        public int GetLevelForExp(int experience)
        {
            var currentLevel = 1;
            for (var i = 1; i <= _experienceRequiredForNextLevel.Count; i++)
            {
                var expRequired = _experienceRequiredForNextLevel[i];
                if (!_experienceRequiredForNextLevel.ContainsKey(i + 1))
                {
                    return experience >= expRequired ? i : currentLevel;
                }

                var expRequiredForNextLevel = _experienceRequiredForNextLevel[i +1];

                if (experience >= expRequired && experience < expRequiredForNextLevel)
                {
                    currentLevel = i;
                }
            }
            return currentLevel;
        }
    }
}