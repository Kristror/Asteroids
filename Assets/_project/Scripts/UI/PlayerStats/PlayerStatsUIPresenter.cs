using Zenject;

namespace UI
{
    public class PlayerStatsUIPresenter : IInitializable, IFixedTickable
    {
        private PlayerStatsUIModel _playerStatsUIModel;
        private PlayerStatsUIView _playerStatsUIView;

        public PlayerStatsUIPresenter(PlayerStatsUIModel playerStatsUIModel)
        {
            _playerStatsUIModel = playerStatsUIModel;
        }
        public void Initialize()
        {
            _playerStatsUIModel.SetLaserShooting();
        }

        public void SetView(PlayerStatsUIView playerStatsUIView)
        {
            _playerStatsUIView = playerStatsUIView;
        }        

        public void FixedTick()
        {
            _playerStatsUIModel.UpdateData();

            UpdatePlayerPosition();
            UpdatePlayerRotation();
            UpdatePlayerSpeed();

            UpdateLaserAmmo();
            UpdateLaserReloadTime();
        }

        private void UpdatePlayerPosition()
        {
            _playerStatsUIView.ShowPosition(_playerStatsUIModel.PlayerPosition);
        }
        
        private void UpdatePlayerRotation()
        {
            _playerStatsUIView.ShowRotation(_playerStatsUIModel.PlayerRotation);
        }
        
        private void UpdatePlayerSpeed()
        {
            _playerStatsUIView.ShowSpeed(_playerStatsUIModel.PlayerSpeed);
        }

        private void UpdateLaserAmmo()
        {
            _playerStatsUIView.ShowLaserAmmo(_playerStatsUIModel.LaserAmmo);
        }

        private void UpdateLaserReloadTime()
        {
            _playerStatsUIView.ShowLaserReloadTime(_playerStatsUIModel.LaserCooldown);
        }        
    }
}