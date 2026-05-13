using Player;
using System;

namespace UI
{
    public class PlayerStatsUIModel 
    {
        public string PlayerPosition => _playerProvider.PlayerPosition.ToString();
        public string PlayerRotation => Math.Round(_playerProvider.PlayerRotation, 1).ToString();
        public string PlayerSpeed => Math.Round(_playerProvider.PlayerSpeed, 1).ToString();

        public string LazerAmmo => _playerLazerShooting.Ammo.ToString();
        public string LazerReloadTime => Math.Round(_playerLazerShooting.TimeToReload(), 1).ToString();

        private PlayerProvider _playerProvider;
        private PlayerLazerShooting _playerLazerShooting;

        public PlayerStatsUIModel(PlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        public void SetLazerShooting()
        {
            _playerLazerShooting = _playerProvider.PlayerLazerShooting;
        }
    }
}