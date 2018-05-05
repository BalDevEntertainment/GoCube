using GoCube.Domain.Ads;
using GoCube.Domain.Provider;
using GoCube.Infraestructure.GameEntity;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

namespace GoCube.Presentation.GameOver
{
    public class GameOverComponent : MonoBehaviour, IGameOverUi
    {
        [SerializeField] private Button _reviveButton;
        [SerializeField] private Button _replayButton;
        private float _accumulatedTime;
        private IGameOverUi _gameOverUi;
        private GameOverMenu _gameOverMenu;
        private bool _revive;
        private Animator _animator;
        private AdsService adsService;

        private void Awake() {
            adsService = ServiceProvider.ProvideAdsService();
            _gameOverMenu = new GameOverMenu(this,
                GameObject.FindWithTag("GameManager").GetComponent<GameManagerComponent>());
            _reviveButton.onClick.AddListener(ShowVideoReward);
            _replayButton.onClick.AddListener(() =>
            {
                _replayButton.interactable = false;
                _gameOverMenu.RestartGame();
            });
            _animator = GetComponent<Animator>();
        }

        private void ShowVideoReward() {
            adsService.PlayVideoReward(OnSuccessVideoReward, OnSkipVideoReward);
        }

        private void Start()
        {
            _gameOverMenu.GameInitialized();
        }

        private void Update() {
            if (_reviveButton) _reviveButton.interactable = Advertisement.IsReady("video");
        }

        private void OnDestroy()
        {
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

        private void OnSkipVideoReward() {
            _gameOverMenu.RestartGame();
        }

        private void OnSuccessVideoReward() {
            _gameOverMenu.ResumeGame();
        }
    }

}