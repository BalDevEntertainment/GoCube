using UnityEngine;
using System.Collections;
using GoCube.Domain.Provider;
using GoCube.Domain.Score;
using GoCube.Domain.ScoreEntity;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class GooglePlayServicesComponent : MonoBehaviour
{
	public string Leaderboard;
	private ScoreService _scoreService;

	void Start () {
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
		_scoreService = ServiceProvider.ProvideScore();
	}

	public void OnShowLeaderBoard () {
		if (!PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.localUser.Authenticate (authenticated => {
				if (authenticated) {
					PlayGamesPlatform.Instance.ReportScore (_scoreService.FindMaxScore(), Leaderboard, success => {
						if (success) {
							ShowLeaderBoard();
						} else {
							Debug.Log ("Update Score Fail");
						}
					});
				} else {
					Debug.Log ("Login failed");
				}
			});
		}
		else {
			ShowLeaderBoard();
		}
	}


	void ShowLeaderBoard() {
		PlayGamesPlatform.Instance.ShowLeaderboardUI(Leaderboard);
	}

}