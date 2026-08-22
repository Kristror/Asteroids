namespace PlayerAnalytics
{
    public class PlayerStatistics
    {

        public const string SHOTS_FIRED_NAME = "ShotsFired";
        public const string LASER_FIRED_NAME = "LaserFired";
        public const string ASTEROIDS_KILLED_NAME = "AsteroidsKilled";
        public const string UFO_KILLED_NAME = "UfoKilled";

        public int ShotsFired;
        public int LaserFired;
        public int AsteroidsKilled;
        public int UfoKilled;

        public PlayerStatistics()
        {
            ShotsFired = 0;
            LaserFired = 0;
            AsteroidsKilled = 0;
            UfoKilled = 0;
        }
    }
}