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
            _playerReviveController.SubscribeToReviveAction(ShowRevardedAd);
            _playerReviveController.SubscribeToAcceptDeath(ShowSimpleAd);
        }

        public void ShowRevardedAd()
        {
            _showAds.RewardedAd();
        }

        public void ShowSimpleAd()
        {
            _showAds.SimpleAd();
        }

        public void SubscirbeToReward(Action func) 
        {
            _showAds.SubscirbeToReward(func);
        }

        public void UnsubscribeFromReward(Action func) 
        {
            _showAds.UnsubscribeFromReward(func);
        }

        public void Dispose()
        {
            _showAds.Dispose();
            _playerReviveController.UnsubscribeFromReviveAction(ShowRevardedAd);
            _playerReviveController.UnsubscribeFromAcceptDeath(ShowSimpleAd);
        }
    }
}