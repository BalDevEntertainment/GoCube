namespace GoCube.Domain.ScoreEntity {
    
    public interface IScoreRepository {
        int Add(int quantity);
        void Clear();
    }
}