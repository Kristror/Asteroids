using Player;
using System;
using Utilities;
using Zenject;

namespace Saving
{
    public class PlayerSaveController : IInitializable, IDisposable
    {
        private IPlayerSaveLoad _playerSave;
        private ScoreController _scoreController;
        private PlayerReviveController _playerReviveController;

        public PlayerSaveController(PlayerReviveController playerReviveController, ScoreController scoreController, IPlayerSaveLoad playerSave)
        {
            _playerReviveController = playerReviveController;
            _scoreController = scoreController;
            _playerSave = playerSave;
        }

        public void Initialize()
        {
            _playerReviveController.AcceptDeathAction += CompareBestScore;
        }

        public void Dispose()
        {
            _playerReviveController.AcceptDeathAction -= CompareBestScore;
        }

        private void CompareBestScore()
        {
            if (_playerSave.IsThereSave())
            {
                PlayerSaveData playerSave = _playerSave.Load();

                if (playerSave.BestScore < _scoreController.PlayerScore)
                {
                    SaveNewScore();
                }
            }
            else
            {
                SaveNewScore();
            }
        }

        private void SaveNewScore()
        {
            PlayerSaveData saveData = new PlayerSaveData(_scoreController.PlayerScore);
            _playerSave.Save(saveData);
        }
    }
}