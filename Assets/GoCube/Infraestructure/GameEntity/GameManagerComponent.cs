using GoCube.Presentation.PlayerEntity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

namespace GoCube.Infraestructure.GameEntity
{

    public class GameManagerComponent : MonoBehaviour
    {

        private string _androidGameId = "1694396";

        [SerializeField]
        private PlayerComponent _player;

        private void Awake() {
            Advertisement.Initialize(_androidGameId);
        }

        private void Start()
        {
            _player.SetOnDeath(EndGame);
        }

        private void EndGame()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}