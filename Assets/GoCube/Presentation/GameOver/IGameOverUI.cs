namespace GoCube.Presentation.GameOver
{
    public interface IGameOverUi
    {
        void Show(bool hasRevived);
        void Hide();
    }
}