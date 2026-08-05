namespace PlayerAnalytics
{
    public class PlayerStatisticsController 
    {
        private PlayerStatistics _playerStatistics;

        public PlayerStatisticsController()
        {
            _playerStatistics = new PlayerStatistics();
        }

        public PlayerStatistics GetPlayerStatistics()
        {
            return _playerStatistics;
        }

        public void ShotBullet()
        {
            _playerStatistics.ShotsFired++;
        }

        public void ShotLazer()
        {
            _playerStatistics.LazerFired++;
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