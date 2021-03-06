﻿using System;

namespace GoCube.Domain.GameEntity
{
    public interface IGameEvents
    {
        event Action<bool> OnPlayerDies;
        event Action OnGameStart;
        event Action OnGameInitialized;
        event Action OnAddScoreToExperience;
        void StartGame();
        void RestartGame();
        void ResumeGame();
    }
}