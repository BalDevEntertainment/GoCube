using System;

namespace GoCube.Domain.Ads {
    public interface IAdsProvider {
        void ShowVideoReward(Action<VideoRewardResult> callback);
    }
}