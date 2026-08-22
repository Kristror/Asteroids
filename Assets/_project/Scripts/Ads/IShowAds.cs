using System;

namespace Ads
{
    public interface IShowAds 
    {
        public void RewardedAd();

        public void SimpleAd();

        public void SubscirbeToReward(Action func);

        public void UnsubscribeFromReward(Action func);

        public void Dispose();
    }
}