using Player;

namespace UI
{
    public class PlayerReviveModel
    {
        private PlayerReviveController _playerReviveController;

        public PlayerReviveModel(PlayerReviveController playerReviveController)
        {
            _playerReviveController = playerReviveController;
        }

        public void Revive()
        {
            _playerReviveController.Revive();
        }

        public void AcceptDeath()
        {
            _playerReviveController.AcceptDeath();
        }
    }
}