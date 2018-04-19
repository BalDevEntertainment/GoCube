using GoCube.Domain.Provider;
using GoCube.Domain.ScoreEntity;
using GoCube.Infraestructure.GameEntity;
using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.ScoreUi
{
    public class ScoreComponent : MonoBehaviour, IScoreUi
    {
        [SerializeField] private Text _maxScoreText;
        [SerializeField] private Text _scoreText;

        private Score _score;
        private bool _shouldDecrease;
        private float _acumulatedTime;
        private Animator _animator;
        private int _currentScoreValue;

        void Awake()
        {
            _score = new Score(this, ServiceProvider.ProvideScore(),
                GameObject.FindWithTag("GameManager").GetComponent<GameManagerComponent>());
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!_shouldDecrease) return;

            _acumulatedTime += Time.deltaTime;
            if (HasReachedDepleteTime())
            {
                ResetDepletion();
            }
            else
            {
                DepleteScore();
            }
        }

        private bool HasReachedDepleteTime()
        {
            return _acumulatedTime > 1;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void OnMaxScoreChanged(int score)
        {
            _maxScoreText.text = score.ToString("0000");
        }

        public void OnScoreChanged(int score)
        {
            _currentScoreValue = score;
            _scoreText.text = _currentScoreValue.ToString("0000");
        }

        public void DecreaseScoreToZero()
        {
            _animator.SetTrigger("Bounce");
        }

        public void OnDecreaseScoreAnimationFinished()
        {
            _shouldDecrease = true;
        }

        private void OnDestroy()
        {
            _score.Destroy();
        }

        private void DepleteScore()
        {
            _scoreText.text = CalculateCurrentDepletionValue().ToString("0000");
        }

        private float CalculateCurrentDepletionValue()
        {
            var actualDepletionPercentage = _acumulatedTime * 100;
            return _currentScoreValue - actualDepletionPercentage * _currentScoreValue / 100;
        }

        private void ResetDepletion()
        {
            _scoreText.text = 0.ToString("0000");
            _shouldDecrease = false;
            _acumulatedTime = 0;
        }
    }
}