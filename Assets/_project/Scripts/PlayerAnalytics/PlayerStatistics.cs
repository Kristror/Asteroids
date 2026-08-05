namespace PlayerAnalytics
{
    public class PlayerStatistics
    {
        public int ShotsFired;
        public int LazerFired;
        public int AsteroidsKilled;
        public int UfoKilled;

        public const string ShotsFiredName= "ShotsFired";
        public const string LazerFiredName = "LazerFired";
        public const string AsteroidsKilledName = "AsteroidsKilled";
        public const string UfoKilledName = "UfoKilled";

        public PlayerStatistics()
        {
            ShotsFired = 0;
            LazerFired = 0;
            AsteroidsKilled = 0;
            UfoKilled = 0;
        }
    }
}