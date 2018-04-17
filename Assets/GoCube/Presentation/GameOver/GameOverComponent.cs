using GoCube.Domain.Ads;
using GoCube.Infraestructure.GameEntity;
using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.GameOver
{
    public class GameOverComponent : MonoBehaviour, IGameOverUi
    {
        [SerializeField] private Button _reviveButton;
        [SerializeField] private Button _replayButton;
        [SerializeField] private AdsComponent _adsComponent;
        private float _accumulatedTime;
        private IGameOverUi _gameOverUi;
        private GameOverMenu _gameOverMenu;
        private bool _revive;
        private Animator _animator;

        private void Awake()
        {
            _gameOverMenu = new GameOverMenu(this,
                GameObject.FindWithTag("GameManager").GetComponent<GameManagerComponent>());
            _adsComponent.OnAdsVideoResult += OnAdsVideoResult;
            _reviveButton.onClick.AddListener(() => { _revive = true;});
            _replayButton.onClick.AddListener(() =>
            {
                _replayButton.interactable = false;
                _gameOverMenu.RestartGame();
            });
            _animator = GetComponent<Animator>();
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

        public void Show(bool hasRevived)
        {
            gameObject.SetActive(true);
            _animator.SetInteger("Order", hasRevived ? 0 : Random.Range(1, 3));
        }

        public void Hide()
        {
            gameObject.SetActive(false);
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
        }
    }
}