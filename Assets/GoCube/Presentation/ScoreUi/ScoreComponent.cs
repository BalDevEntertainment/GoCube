using GoCube.Domain.Provider;
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

        void Start()
        {
            _score = new Score(this, ServiceProvider.ProvideScore(),
                GameObject.FindWithTag("GameManager").GetComponent<GameManagerComponent>());
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
            _scoreText.text = score.ToString("0000");
        }

        private void OnDestroy()
        {
            _score.Destroy();
        }
    }
}