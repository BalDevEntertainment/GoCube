using System;

namespace GoCube.Domain.Ads {

    public class AdsService {

        private readonly IAdsProvider adsProvider;

        public AdsService(IAdsProvider adsProvider) {
            this.adsProvider = adsProvider;
        }

        public void PlayVideoReward(Action onSuccess, Action onCancel) {
            adsProvider.ShowVideoReward(result => {
                if (SkipOrFail(result)) {
                    onCancel();
                } else {
                    onSuccess();
                }
            });
        }

        private static bool SkipOrFail(VideoRewardResult result) {
            return result.ResultType.Equals(ResultType.Failed) || result.ResultType.Equals(ResultType.Skipped);
        }
    }
}