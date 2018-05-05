using GooglePlayGames;
using UnityEngine;

namespace GoCube.Domain.Score {

    public class LeaderBoardScoreService {

        private readonly string highScoreLeaderBoard;

        public LeaderBoardScoreService(string highScoreLeaderBoard) {
            this.highScoreLeaderBoard = highScoreLeaderBoard;
        }

        public void UpdateLeaderBoard(int actualScore) {
            var authenticated = PlayGamesPlatform.Instance.localUser.authenticated;
            Debug.Log("Authenticated at update leaderboard: " + authenticated);
            if (authenticated) {
                PlayGamesPlatform.Instance.ReportScore(actualScore, highScoreLeaderBoard, (bool success) => {
                    if (success) {
                        Debug.Log ("Update Score Success");
                    } else {
                        Debug.Log ("Update Score Fail");
                    }
                });
            }
        }
    }
}