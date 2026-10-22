using System;

namespace Ads
{
    public interface IShowAds 
    {
        public void DisableAds();

        public void RewardedAd();

        public void SimpleAd();

        public void SubscribeToReward(Action func);

        public void UnsubscribeFromReward(Action func);
    }
}