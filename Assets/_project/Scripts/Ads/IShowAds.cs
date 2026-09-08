using System;

namespace Ads
{
    public interface IShowAds 
    {
        public void RewardedAd();

        public void SimpleAd();

        public void SubscribeToReward(Action func);

        public void UnsubscribeToReward(Action func);
    }
}