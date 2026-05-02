using Zenject;

namespace UI
{
    public class PlayerStatsUIPresenter : IInitializable,ITickable
    {
        private PlayerStatsUIModel _playerStatsUIModel;
        private PlayerStatsUIView _playerStatsUIView;

        public PlayerStatsUIPresenter(PlayerStatsUIModel playerStatsUIModel)
        {
            _playerStatsUIModel = playerStatsUIModel;
        }
        public void Initialize()
        {
            _playerStatsUIModel.SetLazerShooting();
        }

        public void SetView(PlayerStatsUIView playerStatsUIView)
        {
            _playerStatsUIView = playerStatsUIView;
        }        

        public void Tick()
        {
            UpdatePlayerPosition();
            UpdatePlayerRotation();
            UpdatePlayerSpeed();

            UpdateLazerAmmo();
            UpdateLazerReloadTime();
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

        private void UpdateLazerAmmo()
        {
            _playerStatsUIView.ShowLazerAmmo(_playerStatsUIModel.LazerAmmo);
        }

        private void UpdateLazerReloadTime()
        {
            _playerStatsUIView.ShowLazerReloadTime(_playerStatsUIModel.LazerReloadTime);
        }        
    }
}