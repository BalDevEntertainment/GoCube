using System;
using Assets.GoCube.Domain.Ads;
using GoCube.Infraestructure.GameEntity;
using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.GameOverMenu
{
    public class GameOverComponent : MonoBehaviour
    {
        [SerializeField] private float _timeToRevive = 5f;
        [SerializeField] private GameManagerComponent _gameManagerComponent;
        [SerializeField] private Image _reviveIcon;
        [SerializeField] private AdsComponent _adsComponent;
        private float _accumulatedTime;
        private bool _hasClickRevive;

        private void Start()
        {
            _gameManagerComponent.OnPlayerDies += ShowGameOver;
           gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!_hasClickRevive) {
                _accumulatedTime += Time.deltaTime;
                _reviveIcon.fillAmount = 1 - _accumulatedTime / _timeToRevive;

                if (Math.Abs(_accumulatedTime - _timeToRevive) < 0.01f)
                {
                    _gameManagerComponent.RestartGame();
                }
            }
        }

        private void OnEnable()
        {
            Reset();
        }

        private void ShowGameOver()
        {
            gameObject.SetActive(true);
            _adsComponent.GetComponent<Button>().onClick.AddListener(() => { _hasClickRevive = true; });
            _adsComponent.OnAdsVideoResult += OnAdsVideoResult;
        }

        private void OnAdsVideoResult(ResultType resultType) {
            if (resultType.Equals(ResultType.Failed) || resultType.Equals(ResultType.Skipped)) {
                _gameManagerComponent.RestartGame();
            }
            else {
                _gameManagerComponent.Resume();
                gameObject.SetActive(false);
            }
            Reset();
        }

        private void Reset() {
            _hasClickRevive = false;
            _reviveIcon.fillAmount = 1;
            _accumulatedTime = 0f;
        }
    }
}
