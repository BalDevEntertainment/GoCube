using System;
using GoCube.Domain.Ads;
using UnityEngine.Advertisements;

namespace GoCube.Infraestructure.Ads {
    public class UnityAdsProvider : IAdsProvider {
        private string placementId = "rewardedVideo";

        public void ShowVideoReward(Action<VideoRewardResult> callback) {
            var options = new ShowOptions();
            options.resultCallback = result => ExecuteCallback(result, callback);
            Advertisement.Show(placementId, options);
        }

        private void ExecuteCallback(ShowResult result, Action<VideoRewardResult> callback) {
            if(result == ShowResult.Finished) {
                callback(new VideoRewardResult(ResultType.Finished));
            }else if(result == ShowResult.Skipped) {
                callback(new VideoRewardResult(ResultType.Skipped));
            }else if(result == ShowResult.Failed) {
                callback(new VideoRewardResult(ResultType.Failed));
            }
        }
    }
}