namespace GoCube.Presentation.ScoreUi
{
    public interface IScoreUi
    {
        void Show();
        void Hide();
        void OnMaxScoreChanged(int score);
        void OnScoreChanged(int score);
        void DecreaseScoreToZero(float inSeconds);
    }
}