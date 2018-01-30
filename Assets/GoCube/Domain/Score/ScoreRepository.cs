namespace Assets.GoCube.Domain.Score {
    
    public interface ScoreRepository {
        int Add(int quantity);
        void Clear();
    }
}