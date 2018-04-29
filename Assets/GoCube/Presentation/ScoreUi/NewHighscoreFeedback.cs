using GoCube.Domain.Provider;
using UnityEngine;

namespace GoCube.Presentation.ScoreUi
{
    public class NewHighscoreFeedback : MonoBehaviour
    {
        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
            ServiceProvider.ProvideScore().MaxScoreReached += NewHighscore;
        }

        private void NewHighscore(int obj)
        {
            ServiceProvider.ProvideScore().MaxScoreReached -= NewHighscore;
            _animator.SetTrigger("NewHighscore");
        }
    }
}