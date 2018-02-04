using GoCube.Domain.Score;
using GoCube.Infraestructure.Score;
using GoCube.Util;

namespace GoCube.Infraestructure.Provider {

    public class InfrastructureProvider {

        public static ScoreRepository ProvideScore() {
            return ProviderCache.GetOrInstanciate<ScoreRepository>(() => new InMemoryScoreRepository());
        }

        public static MaxScoreRepository ProvideMaxScore() {
            return ProviderCache.GetOrInstanciate<MaxScoreRepository>(() => new LocalMaxScoreRepository());
        }
    }
}