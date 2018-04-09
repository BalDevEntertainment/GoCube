using System;
using System.Collections.Generic;
using Assets.GoCube.Domain.Spawner;
using GoCube.Domain.GameCamera;
using GoCube.Domain.GameEntity;
using GoCube.Presentation.PlayerEntity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

namespace GoCube.Infraestructure.GameEntity {
    public class GameManagerComponent : MonoBehaviour, IGameEvents {
        public event Action<bool> OnPlayerDies = delegate { };
        public event Action OnGameStart = delegate { };

        private string _androidGameId = "1694396";

        [SerializeField] private PlayerComponent _player;

        [SerializeField] private CameraPointer _anchor;

        private List<GameObject> enemies = new List<GameObject>();

        public GameObject EnemyPrefab;

        public void StartGame() {
            var enemySpawner = new EnemySpawner(new PointerDistanceTrigger(_anchor, 6));
            enemySpawner.NewSpawn += OnNewSpawn;
            OnGameStart();
        }

        private void OnNewSpawn() {
            var anchorTransform = _anchor.transform;
            var random = new System.Random();
            var enemy = Instantiate(EnemyPrefab, new Vector3(anchorTransform.position.x + random.Next(5, 8),
                    EnemyPrefab.transform.position.y,
                    EnemyPrefab.transform.position.z),
                Quaternion.identity);
            enemies.Add(enemy);
        }

        public void RestartGame() {
            SceneManager.LoadScene("MainScene");
        }

        public void ResumeGame() {
            _anchor.Reset();
            _player.Revive();
        }

        private void Awake() {
            Advertisement.Initialize(_androidGameId);
        }

        private void Start() {
            _player.SetOnDeath(() => { OnPlayerDies.Invoke(_player.HasRevived()); });
            _player.SetOnRevive(() => {
                enemies.ForEach(Destroy);
                enemies.Clear();
            });
        }
    }
}