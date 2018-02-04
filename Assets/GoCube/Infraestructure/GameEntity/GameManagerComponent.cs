using GoCube.Presentation.PlayerEntity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GoCube.Infraestructure.GameEntity
{
    public class GameManagerComponent : MonoBehaviour
    {
        [SerializeField]
        private PlayerComponent _player;

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