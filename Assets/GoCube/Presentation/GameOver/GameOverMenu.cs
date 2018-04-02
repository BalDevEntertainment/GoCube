using GoCube.Domain.GameEntity;

namespace GoCube.Presentation.GameOver
{
    public class GameOverMenu
    {
        private readonly IGameOverUi _gameOverUi;
        private readonly IGameEvents _gameEvents;

        public GameOverMenu(IGameOverUi gameOverUi, IGameEvents gameEvents)
        {
            _gameOverUi = gameOverUi;
            _gameEvents = gameEvents;
            Init();
            _gameOverUi.Hide();
        }

        private void Init()
        {
            _gameEvents.OnPlayerDies += ShowGameOver;
        }

        public void Destroy()
        {
            _gameEvents.OnPlayerDies -= ShowGameOver;
        }

        private void ShowGameOver(bool hasRevived)
        {
            if(!hasRevived)
                _gameOverUi.Show();
            else
                _gameEvents.RestartGame();
        }

        public void ReviveTimeIsOver()
        {
            _gameEvents.RestartGame();
        }

        public void RestartGame()
        {
            _gameEvents.RestartGame();
        }

        public void ResumeGame()
        {
            _gameOverUi.Hide();
            _gameEvents.ResumeGame();
        }
    }
}