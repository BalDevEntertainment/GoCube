using GoCube.Domain.Ads;
using GoCube.Domain.Score;
using GoCube.Infraestructure.Ads;
using GoCube.Infraestructure.Provider;
using GoCube.Util;

namespace GoCube.Domain.Provider {
    public class ServiceProvider {

        public static ScoreService ProvideScore()
        {
            return ProviderCache.GetOrInstanciate<ScoreService>(() => new ScoreService(
                InfrastructureProvider.ProvideScore(),
                InfrastructureProvider.ProvideMaxScore(),
                ProvideLeaderBoardScore()));
        }

        public static AdsService ProvideAdsService() {
            return ProviderCache.GetOrInstanciate<AdsService>(() => new AdsService(new UnityAdsProvider()));
        }

        public static LeaderBoardScoreService ProvideLeaderBoardScore() {
            return ProviderCache.GetOrInstanciate<LeaderBoardScoreService>(() => new LeaderBoardScoreService("CgkIvJL6kN8LEAIQAA"));
        }
    }
}