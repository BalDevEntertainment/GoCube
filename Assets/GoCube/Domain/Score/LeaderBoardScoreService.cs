using UnityEngine;

namespace GoCube.Domain.Score {

    public class LeaderBoardScoreService {

        private readonly string highScoreLeaderBoard;

        public LeaderBoardScoreService(string highScoreLeaderBoard) {
            this.highScoreLeaderBoard = highScoreLeaderBoard;
        }

        public void UpdateLeaderBoard(int actualScore) {
            if (Social.localUser.authenticated) {
                Social.ReportScore (actualScore, highScoreLeaderBoard, (bool success) => {
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