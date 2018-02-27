namespace GoCube.Domain.Ads {
    public class VideoRewardResult {
        public ResultType ResultType{ get; private set; }

        public VideoRewardResult(ResultType resultType) {
            ResultType = resultType;
        }

    }
}