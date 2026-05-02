using Player;
using System;

namespace UI
{
    public class PlayerStatsUIModel 
    {
        public string PlayerPosition => _playerCointroler.PlayerPosition.ToString();
        public string PlayerRotation => Math.Round(_playerCointroler.PlayerRotation, 1).ToString();
        public string PlayerSpeed => Math.Round(_playerCointroler.PlayerSpeed, 1).ToString();

        public string LazerAmmo => _playerLazerShooting.Ammo.ToString();
        public string LazerReloadTime => Math.Round(_playerLazerShooting.TimeToReload(), 1).ToString();

        private PlayerObject _playerCointroler;
        private PlayerLazerShooting _playerLazerShooting;

        public PlayerStatsUIModel(PlayerObject playerController)
        {
            _playerCointroler = playerController;
        }

        public void SetLazerShooting()
        {
            _playerLazerShooting = _playerCointroler.PlayerLazerShooting;
        }
    }
}