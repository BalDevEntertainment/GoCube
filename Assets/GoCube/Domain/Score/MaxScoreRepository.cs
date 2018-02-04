namespace GoCube.Domain.Score {
    public interface MaxScoreRepository {
        int Find();
        void Update(int actualScore);
        void Clear();
    }
}