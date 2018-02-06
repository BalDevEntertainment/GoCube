using System;

namespace Assets.GoCube.Domain.Ads {

    public class AdsService {

        public event Action<VideoRewardResult> VideoAdExecuted = delegate { };
        private readonly IAdsProvider adsProvider;

        public AdsService(IAdsProvider adsProvider) {
            this.adsProvider = adsProvider;
        }

        public void PlayVideoReward() {
            adsProvider.ShowVideoReward(result => VideoAdExecuted(result));
        }
    }
}