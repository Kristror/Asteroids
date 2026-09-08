using System;
using Zenject;

namespace Configs
{
    public class ConfigsController : IInitializable, IDisposable
    {
        private IConfigsProvider _configsProvider;
        private GameConfigs _gameConfigs;

        public ConfigsController(IConfigsProvider configsProvider)
        {
            _configsProvider = configsProvider;
        }

        public void Initialize()
        {
            _configsProvider.ConfigsLoaded += GetConfigs;
        }
        public void Dispose()
        {
            _configsProvider.ConfigsLoaded -= GetConfigs;
        }

        private void GetConfigs()
        {
            _gameConfigs = _configsProvider.GetGameConfigs();
        }

        public int GetLaserMaxAmmo()
        {
            return _gameConfigs.LaserMaxAmmo;
        }

        public int GetLaserTimeToReload()
        {
            return _gameConfigs.LaserTimeToReload;
        }

        public float GetLaserShootingSpeed()
        {
            return _gameConfigs.LaserShootingSpeed;
        }

        public int GetLaserDuration()
        {
            return _gameConfigs.LaserDuration;
        }

        public int GetBulletTimeToLive()
        {
            return _gameConfigs.BulletTimeToLive;
        }

        public float GetBulletMovementSpeed()
        {
            return _gameConfigs.BulletMovementSpeed;
        }

        public int GetBulletPoolSize()
        {
            return _gameConfigs.BulletPoolSize;
        }

        public float GetBulletShootingSpeed()
        {
            return _gameConfigs.BulletShootingSpeed;
        }

        public int GetAreaActiveTime()
        {
            return _gameConfigs.AreaActiveTime;
        }

        public float GetAreaSize()
        {
            return _gameConfigs.AreaSize;
        }

        public int GetPointsForEnemy()
        {
            return _gameConfigs.PointsForEnemy;
        }

        public float GetPlayerMovementSpeed()
        {
            return _gameConfigs.PlayerMovementSpeed;
        }
        public float GetPlayerRotationSpeed()
        {
            return _gameConfigs.PlayerRotationSpeed;
        }

        public float GetUfoMovementSpeed()
        {
            return _gameConfigs.UfoMovementSpeed;
        }

        public float GetAsteroidMovementSpeed()
        {
            return _gameConfigs.PlayerMovementSpeed;
        }

        public float GetAsteroidSpeedMult()
        {
            return _gameConfigs.AsteroidSpeedMult;
        }

        public int GetAmountOfPieces()
        {
            return _gameConfigs.AmountOfPieces;
        }

        public int GetUfoTimeToSpawn()
        {
            return _gameConfigs.UfoTimeToSpawn;
        }

        public int GetAsteroidTimeToSpawn()
        {
            return _gameConfigs.UfoTimeToSpawn;
        }
    }
}