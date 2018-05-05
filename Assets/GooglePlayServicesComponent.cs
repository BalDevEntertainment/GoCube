using GoCube.Domain.Provider;
using GoCube.Domain.ScoreEntity;
using GooglePlayGames;
using UnityEngine;

public class GooglePlayServicesComponent : MonoBehaviour
{

    private void Awake() {
        PlayGamesPlatform.Activate();
    }

    void Start()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated) {
            PlayGamesPlatform.Instance.localUser.Authenticate(authenticated =>
            {
                Debug.Log("Authenticated at init: " + authenticated);
            });
        }
    }

    public void OnShowLeaderBoard() {
        var authenticated = PlayGamesPlatform.Instance.localUser.authenticated;
        Debug.Log("Authenticated at show leaderboard: " + authenticated);
        if (authenticated) {
            ShowLeaderBoard();
        }
    }


    void ShowLeaderBoard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(LeaderboardManager.leaderboard_highscores);
    }
}