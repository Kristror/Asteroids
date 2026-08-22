namespace PlayerAnalytics
{
    public class PlayerStatisticsController 
    {
        private PlayerStatistics _playerStatistics;

        public PlayerStatisticsController(IAnalytics analytics)
        {
            _playerStatistics = new PlayerStatistics();

            analytics.SetPlayerStatistics(_playerStatistics);
        }

        public PlayerStatistics GetPlayerStatistics()
        {
            return _playerStatistics;
        }

        public void ShotBullet()
        {
            _playerStatistics.ShotsFired++;
        }

        public void ShotLaser()
        {
            _playerStatistics.LaserFired++;
        }

        public void AsteroidKilled()
        {
            _playerStatistics.AsteroidsKilled++;
        }

        public void UfoKilled()
        {
            _playerStatistics.UfoKilled++;
        }
    }
}