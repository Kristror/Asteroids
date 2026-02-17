using UnityEngine;


public static class ScoreController
{
    private static int _pointsForEnemy = 2;

    public static int PlayerScore  {get ; private set ;}

    public static void ResetScore()
    {
        PlayerScore = 0;
    }

    public static void KilledEnemy()
    {
        PlayerScore += _pointsForEnemy;
    }
}