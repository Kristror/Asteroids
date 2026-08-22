namespace PlayerAnalytics
{
    public interface IAnalytics
    {
        void Initialize();

        void SetPlayerStatistics(PlayerStatistics playerStatistics);

        void GameStarted();

        void SendPlayerStatistics();

        void LaserUsed();        
    }
}