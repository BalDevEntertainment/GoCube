using System;

namespace Assets.GoCube.Domain.Ads {
    public interface IAdsProvider {
        void ShowVideoReward(Action<VideoRewardResult> callback);
    }
}