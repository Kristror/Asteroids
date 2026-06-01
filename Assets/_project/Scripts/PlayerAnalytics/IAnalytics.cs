namespace PlayerAnalytics
{
    public interface IAnalytics
    {
        void GameStarted();

        void SendPlayerStatistics();

        void LazerUsed();
    }
}