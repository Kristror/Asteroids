namespace PlayerAnalytics
{
    public interface IAnalytics
    {
        void Initialize();

        void Dispose();

        void GameStarted();

        void SendPlayerStatistics();

        void LazerUsed();        
    }
}