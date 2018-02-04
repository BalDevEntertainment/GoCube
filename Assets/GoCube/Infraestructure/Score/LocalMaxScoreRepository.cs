using GoCube.Domain.Score;
using UnityEngine;

namespace GoCube.Infraestructure.Score {

    public class LocalMaxScoreRepository : MaxScoreRepository {

        private const string MAX_SCORE = "max_score";

        public int Find() {
            return PlayerPrefs.HasKey(MAX_SCORE) ? PlayerPrefs.GetInt(MAX_SCORE) : 0;
        }

        public void Update(int actualScore) {
            PlayerPrefs.SetInt(MAX_SCORE, actualScore);
        }

        public void Clear() {
            PlayerPrefs.DeleteKey(MAX_SCORE);
        }
    }
}