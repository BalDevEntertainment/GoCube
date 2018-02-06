using GoCube.Domain.Provider;
using GoCube.Domain.Score;
using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.Score
{
    public class ScoreUiComponent : MonoBehaviour
    {
        private ScoreService _scoreService;
        private Text _scoreText;

        void Start()
        {
            _scoreService = ServiceProvider.ProvideScore();
            _scoreService.ScoreChanged += OnScoreChanged;
            _scoreText = GetComponent<Text>();
            _scoreText.text = "Score: 0000";
        }

        private void OnDestroy()
        {
            _scoreService.ScoreChanged -= OnScoreChanged;
            _scoreService.ClearScore();
        }

        private void OnScoreChanged(int score)
        {
            _scoreText.text = "Score: " + score.ToString("0000");
        }
    }
}