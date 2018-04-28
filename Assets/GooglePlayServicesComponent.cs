using GoCube.Domain.Provider;
using GoCube.Domain.ScoreEntity;
using GooglePlayGames;
using UnityEngine;

public class GooglePlayServicesComponent : MonoBehaviour
{
    [SerializeField] private string _leaderboard;
    private ScoreService _scoreService;

    void Start()
    {
        PlayGamesPlatform.Activate();
        _scoreService = ServiceProvider.ProvideScore();
    }

    public void OnShowLeaderBoard()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.localUser.Authenticate(authenticated =>
            {
                if (authenticated)
                {
                    PlayGamesPlatform.Instance.ReportScore(_scoreService.FindMaxScore(),
                        _leaderboard, success =>
                        {
                            if (success)
                            {
                                ShowLeaderBoard();
                            }
                        });
                }
            });
        }
        else
        {
            ShowLeaderBoard();
        }
    }


    void ShowLeaderBoard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(_leaderboard);
    }
}