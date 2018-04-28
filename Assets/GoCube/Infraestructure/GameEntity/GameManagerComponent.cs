using System;
using System.Collections;
using System.Collections.Generic;
using Assets.GoCube.Domain.Spawner;
using GoCube.Domain.Economy;
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
        public event Action OnGameInitialized = delegate { };
        public event Action OnAddScoreToExperience = delegate { };

        public GameObject EnemyPrefab;
        public GameObject CoinPrefab;

        [SerializeField] private PlayerComponent _player;
        [SerializeField] private CameraPointer _anchor;
        [SerializeField] private UnityEngine.Camera _camera;

        private string _androidGameId = "1755417";
        private readonly List<GameObject> _enemies = new List<GameObject>();

        public void StartGame() {
            var enemySpawner = new EnemySpawner(new PointerDistanceTrigger(_anchor, 6));
            enemySpawner.NewSpawn += OnNewEnemySpawn;
            var coinsSpawner = new CoinsSpawner(new PointerDistanceTrigger(_anchor, 3));
            coinsSpawner.NewSpawn += OnNewCoinSpawn;
            OnGameStart();
        }

        private void OnNewEnemySpawn() {
            var anchorTransform = _anchor.transform;
            var random = new System.Random();
            var enemy = Instantiate(EnemyPrefab, new Vector3(anchorTransform.position.x + random.Next(5, 8),
                    EnemyPrefab.transform.position.y,
                    EnemyPrefab.transform.position.z),
                Quaternion.identity);
            _enemies.Add(enemy);
        }

        private void OnNewCoinSpawn(int quantity) {
            var anchorTransform = _anchor.transform;
            var random = new System.Random();
            Instantiate(CoinPrefab, new Vector3(anchorTransform.position.x + random.Next(5, 8),
                    CoinPrefab.transform.position.y,
                    CoinPrefab.transform.position.z),
                Quaternion.identity);
        }

        public void RestartGame()
        {
            OnAddScoreToExperience.Invoke();
            StartCoroutine(ReloadScene(2));
        }

        private IEnumerator ReloadScene(int waitTime)
        {
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
                SceneManager.LoadScene("MainScene");
            }
        }

        public void ResumeGame() {
            _anchor.Reset();
            _player.Revive();
        }

        private void Awake() {
            Advertisement.Initialize(_androidGameId);
        }

        private void Start() {
            _player.SetOnDeath(() => OnPlayerDies.Invoke(_player.HasRevived()));

            _player.SetOnRevive(() => {
                _enemies.ForEach(Destroy);
                _enemies.Clear();
            });

            OnGameInitialized.Invoke();
        }
    }
}