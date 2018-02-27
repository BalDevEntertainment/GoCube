using System;
using GoCube.Domain.GameEntity;
using GoCube.Presentation;
using GoCube.Presentation.PlayerEntity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

namespace GoCube.Infraestructure.GameEntity
{

    public class GameManagerComponent : MonoBehaviour, IGameEvents
    {
        public event Action OnPlayerDies = delegate {  };
        public event Action OnGameStart = delegate {  };

        private string _androidGameId = "1694396";

        [SerializeField]
        private PlayerComponent _player;

        public void StartGame()
        {
            OnGameStart();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("MainScene");
        }

        public void ResumeGame()
        {
            _player.Revive();
        }

        private void Awake() {
            Advertisement.Initialize(_androidGameId);
        }

        private void Start()
        {
            _player.SetOnDeath(() => {
                OnPlayerDies.Invoke();
            });
        }

        public void Resume() {
            _player.Revive();
        }

    }
}