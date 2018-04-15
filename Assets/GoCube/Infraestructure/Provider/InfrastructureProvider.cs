using GoCube.Domain.ScoreEntity;
using GoCube.Infraestructure.Score;
using GoCube.Util;

namespace GoCube.Infraestructure.Provider {

    public class InfrastructureProvider {

        public static IScoreRepository ProvideScore() {
            return ProviderCache.GetOrInstanciate<IScoreRepository>(() => new InMemoryScoreRepository());
        }

        public static MaxScoreRepository ProvideMaxScore() {
            return ProviderCache.GetOrInstanciate<MaxScoreRepository>(() => new LocalMaxScoreRepository());
        }
    }
}