using System;
using Unity.Services.LevelPlay;
using UnityEngine;

namespace Ads
{
    public class UnityLevelPlayAds : IShowAds
    {
        private const string APP_KEY = "27a9198ed";
        private const string REWARDED_AD_ID = "0z0yekhx5zrw8kts";
        private const string INTERSTITIAL_AD_ID = "ql9uyfvfhfrl3r61";

        private LevelPlayInterstitialAd _interstitialAd;
        private LevelPlayRewardedAd _rewardedAd;

        private event Action _rewarded;

        public UnityLevelPlayAds()
        {
            Initialize();
        }

        private void Initialize()
        {
            LevelPlay.OnInitSuccess += InitializationCompleted;
            LevelPlay.OnInitFailed += InitializationFailed;

            LevelPlay.Init(APP_KEY);
        }

        private void InitializationCompleted(LevelPlayConfiguration configuration)
        {
            LoadRewarded();
            LoadInterstitial();
        }

        private void InitializationFailed(LevelPlayInitError error)
        {
            Debug.Log(error.ErrorMessage);
        }

        private void LoadRewarded()
        {
            _rewardedAd = new LevelPlayRewardedAd(REWARDED_AD_ID);
            _rewardedAd.OnAdRewarded += RewardForAd;
            _rewardedAd.LoadAd();
        }

        private void LoadInterstitial()
        {
            _interstitialAd = new LevelPlayInterstitialAd(INTERSTITIAL_AD_ID);
            _interstitialAd.LoadAd();
        }

        public void RewardedAd()
        {
            if(_rewardedAd.IsAdReady())
            {
                _rewardedAd.ShowAd();
            }
        }

        public void SimpleAd()
        {
            if (_interstitialAd.IsAdReady())
            {
                _interstitialAd.ShowAd();
            }
        }

        private void RewardForAd(LevelPlayAdInfo adInfo, LevelPlayReward adReward) 
        {
            _rewarded?.Invoke();
        }

        public void SubscirbeToReward(Action func)
        {
            _rewarded += func;
        }

        public void UnsubscribeFromReward(Action func)
        {
            _rewarded -= func;
        }

        public void Dispose()
        {
            _rewardedAd?.Dispose();
            _interstitialAd?.Dispose();
        }
    }
}