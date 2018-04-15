using System;
using GoCube.Domain.Ads;
using GoCube.Infraestructure.GameEntity;
using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.GameOver
{
    public class GameOverComponent : MonoBehaviour, IGameOverUi
    {
        [SerializeField] private float _timeToRevive = 5f;
        [SerializeField] private Image _reviveIcon;
        [SerializeField] private Button _reviveButton;
        [SerializeField] private AdsComponent _adsComponent;
        private float _accumulatedTime;
        private IGameOverUi _gameOverUi;
        private GameOverMenu _gameOverMenu;
        private bool _revive;

        private void Awake()
        {
            _gameOverMenu = new GameOverMenu(this,
                GameObject.FindWithTag("GameManager").GetComponent<GameManagerComponent>());
            _adsComponent.OnAdsVideoResult += OnAdsVideoResult;
            _reviveButton.onClick.AddListener(() => { _revive = true;});
        }

        private void Start()
        {
            _gameOverMenu.GameInitialized();
        }

        private void OnDestroy()
        {
            _adsComponent.OnAdsVideoResult -= OnAdsVideoResult;
            _gameOverMenu.Destroy();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            _accumulatedTime += Time.deltaTime;
            _reviveIcon.fillAmount = 1 - _accumulatedTime / _timeToRevive;

            if (Math.Abs(_accumulatedTime - _timeToRevive) < 0.01f && !_revive)
            {
                _gameOverMenu.ReviveTimeIsOver();
            }
        }

        private void OnEnable()
        {
            Reset();
        }

        private void OnAdsVideoResult(ResultType resultType)
        {
             if (resultType.Equals(ResultType.Failed) || resultType.Equals(ResultType.Skipped))
            {
                _gameOverMenu.RestartGame();
            }
            else
            {
                _gameOverMenu.ResumeGame();
            }
            Reset();
        }

        private void Reset()
        {
            _reviveIcon.fillAmount = 1;
            _accumulatedTime = 0f;
        }
    }
}