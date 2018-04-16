using GoCube.Domain.Provider;
using GoCube.Domain.ScoreEntity;
using UnityEngine;

namespace GoCube.Infraestructure.Score
{
    public class ScoreTrackerComponent : MonoBehaviour
    {
        private ScoreService _scoreService;

        private void Start()
        {
            _scoreService = ServiceProvider.ProvideScore();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _scoreService.IncrementScore(1);
        }
    }
}