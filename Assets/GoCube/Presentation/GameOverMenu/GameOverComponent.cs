using System;
using GoCube.Infraestructure.GameEntity;
using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.GameOverMenu
{
    public class GameOverComponent : MonoBehaviour
    {
        [SerializeField] private float _timeToRevive = 3f;
        [SerializeField] private GameManagerComponent _gameManagerComponent;
        [SerializeField] private Image _reviveIcon;
        private float _accumulatedTime;

        private void Start()
        {
            _gameManagerComponent.OnPlayerDies += ShowGameOver;
           gameObject.SetActive(false);
        }

        private void Update()
        {
            _accumulatedTime += Time.deltaTime;
            _reviveIcon.fillAmount = 1 - _accumulatedTime / _timeToRevive;

            if (Math.Abs(_accumulatedTime - _timeToRevive) < 0.01f)
            {
                _gameManagerComponent.RestartGame();
            }
        }

        private void OnEnable()
        {
            _reviveIcon.fillAmount = 1;
            _accumulatedTime = 0f;
        }

        private void ShowGameOver()
        {
            gameObject.SetActive(true);
        }
    }
}
