using System;

namespace GoCube.Domain.GameEntity
{
    public interface IGameEvents
    {
        event Action OnPlayerDies;
        event Action OnGameStart;
        void StartGame();
    }
}