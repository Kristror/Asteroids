namespace PlayerAnalytics
{
    public interface IAnalytics
    {
        void SetPlayerStatistics(PlayerStatistics playerStatistics);

        void GameStarted();

        void SendPlayerStatistics();

        void LaserUsed();        
    }
}