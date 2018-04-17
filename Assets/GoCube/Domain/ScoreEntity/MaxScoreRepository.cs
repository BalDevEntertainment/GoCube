namespace GoCube.Domain.ScoreEntity {
    public interface MaxScoreRepository {
        int Find();
        void Update(int actualScore);
        void Clear();
    }
}