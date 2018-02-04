﻿using GoCube.Domain.Score;
using GoCube.Infraestructure.Provider;
using GoCube.Util;

namespace GoCube.Domain.Provider {
    public class ServiceProvider {

        public static ScoreService ProvideScore()
        {
            return ProviderCache.GetOrInstanciate<ScoreService>(() => new ScoreService(
                InfrastructureProvider.ProvideScore(),
                InfrastructureProvider.ProvideMaxScore()));
        }

    }
}