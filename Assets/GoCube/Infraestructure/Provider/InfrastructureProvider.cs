using GoCube.Domain.ExperienceEntity;
using GoCube.Domain.PlayerEntity;
using GoCube.Domain.ScoreEntity;
using GoCube.Infraestructure.ExperienceEntity;
using GoCube.Infraestructure.PlayerEntity;
using GoCube.Infraestructure.Score;
using GoCube.Util;

namespace GoCube.Infraestructure.Provider
{
    public class InfrastructureProvider
    {
        public static IScoreRepository ProvideScore()
        {
            return ProviderCache.GetOrInstanciate<IScoreRepository>(() =>
                new InMemoryScoreRepository());
        }

        public static MaxScoreRepository ProvideMaxScore()
        {
            return ProviderCache.GetOrInstanciate<MaxScoreRepository>(() =>
                new LocalMaxScoreRepository());
        }

        public static IExperienceRepository ProvideExperience()
        {
            return ProviderCache.GetOrInstanciate<IExperienceRepository>(() =>
                new PlayerPrefsExperienceRepository());
        }

        public static IPlayerLevelProgression ProvidePlayerLevelProgression()
        {
             return ProviderCache.GetOrInstanciate<IPlayerLevelProgression>(() =>
                new InMemoryPlayerLevelProgression());        }
    }
}