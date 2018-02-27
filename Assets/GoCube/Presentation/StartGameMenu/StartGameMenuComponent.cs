using GoCube.Domain.GameEntity;
using GoCube.Infraestructure.GameEntity;
using UnityEngine;

namespace GoCube.Presentation.StartGameMenu
{
    public class StartGameMenuComponent : MonoBehaviour
    {
        private IGameEvents _gameManagerComponent;

        private void Start()
        {
            _gameManagerComponent = GameObject.FindWithTag("GameManager")
                .GetComponent<GameManagerComponent>();
            _gameManagerComponent.OnGameStart += Animate;
        }

        private void OnDestroy()
        {
            _gameManagerComponent.OnGameStart -= Animate;
        }

        private void Animate()
        {
            GetComponent<Animator>().SetTrigger("StartGame");
        }
    }
}