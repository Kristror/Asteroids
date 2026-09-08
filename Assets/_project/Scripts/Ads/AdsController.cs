using Player;
using System;
using Zenject;

namespace Ads
{
    public class AdsController: IInitializable, IDisposable
    {
        private IShowAds _showAds;
        private PlayerReviveController _playerReviveController;

        public AdsController(IShowAds showAds, PlayerReviveController playerReviveController)
        {
            _showAds = showAds;
            _playerReviveController = playerReviveController;
        }

        public void Initialize()
        {
            _playerReviveController.ReviveAction += ShowRewardedAd;
            _playerReviveController.AcceptDeathAction += ShowSimpleAd;
        }

        public void ShowRewardedAd()
        {
            _showAds.RewardedAd();
        }

        public void ShowSimpleAd()
        {
            _showAds.SimpleAd();
        }

        public void SubscribeToReward(Action func) 
        {
            _showAds.SubscribeToReward(func);
        }

        public void UnsubscribeToReward(Action func) 
        {
            _showAds.UnsubscribeToReward(func);
        }

        public void Dispose()
        {
            _playerReviveController.ReviveAction -= ShowRewardedAd;
            _playerReviveController.AcceptDeathAction -= ShowSimpleAd;
        }
    }
}