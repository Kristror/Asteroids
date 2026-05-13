using Player;
using System;
using UnityEngine;
using Utilites;
using Zenject;

namespace Saving
{
    public class PlayerSaveController : IInitializable,IDisposable
    {
        private IPlayerSaveLoad _playerSave;
        private ScoreController _scoreController;
        private PlayerProvider _playerProvider;

        public PlayerSaveController(PlayerProvider playerProvider, ScoreController scoreController, IPlayerSaveLoad playerSave)
        {
            _playerProvider = playerProvider;
            _scoreController = scoreController;
            _playerSave = playerSave;

            
        }
        public void Initialize()
        {
            _playerProvider.SubscribeToPlayerDeath(CompareBestScore);
        }
        public void Dispose()
        {
            _playerProvider.UnSubscribeToPlayerDeath(CompareBestScore);
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