using System;

namespace GoCube.Domain.GameEntity
{
    public interface IGameEvents
    {
        event Action<bool> OnPlayerDies;
        event Action OnGameStart;
        void StartGame();
        void RestartGame();
        void ResumeGame();
    }
}