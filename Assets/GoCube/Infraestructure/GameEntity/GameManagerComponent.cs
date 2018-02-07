using System;
using GoCube.Domain.Enemy;
using GoCube.Presentation.PlayerEntity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace GoCube.Infraestructure.GameEntity
{

    public class GameManagerComponent : MonoBehaviour
    {

        private string _androidGameId = "1694396";
        private TimerTrigger spawnTrigger;
        private Vector3 lastEnemyPosition;

        [SerializeField]
        private PlayerComponent _player;

        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private GameObject EnemyPrefab;

        private void Awake() {
            Advertisement.Initialize(_androidGameId);
        }

        private void Start() {
            _player.SetOnDeath(EndGame);

            lastEnemyPosition = EnemyPrefab.transform.position;
            spawnTrigger = new TimerTrigger(2);
            var enemySpawner = new EnemySpawner(spawnTrigger);
            enemySpawner.NewSpawn += SpawnEnemy;
        }

        private void Update() {
            spawnTrigger.Update(Time.deltaTime);
        }

        private void SpawnEnemy() {
            Object.Instantiate(EnemyPrefab, lastEnemyPosition, Quaternion.identity);
            lastEnemyPosition = lastEnemyPosition + new Vector3(new Random().Next(5, 10), lastEnemyPosition.y, lastEnemyPosition.z);
        }

        private void EndGame()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}