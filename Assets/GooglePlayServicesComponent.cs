using UnityEngine;
using System.Collections;
using GoCube.Domain.Provider;
using GoCube.Domain.Score;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
public class GooglePlayServicesComponent : MonoBehaviour
{
	public string leaderboard;
	private ScoreService scoreService;

	void Start () {
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
		scoreService = ServiceProvider.ProvideScore();
	}

	public void OnShowLeaderBoard () {
		if (!Social.localUser.authenticated) {
			Social.localUser.Authenticate ((bool authenticated) => {
				if (authenticated) {
					Social.ReportScore (scoreService.FindMaxScore(), leaderboard, (bool success) => {
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
		((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (leaderboard);
	}

}