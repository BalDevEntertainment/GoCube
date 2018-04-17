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
        }

        private void Init()
        {
            _gameEvents.OnPlayerDies += ShowGameOver;
        }

        public void GameInitialized()
        {
            _gameOverUi.Hide();
        }

        public void Destroy()
        {
            _gameEvents.OnPlayerDies -= ShowGameOver;
        }

        private void ShowGameOver(bool hasRevived)
        {
            _gameOverUi.Show(hasRevived);
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