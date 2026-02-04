using UnityEngine;


public static class Score
{
    private static int _pointsForEnemy;

    private static int _playerScore = 0;

    public static int PlayerScore => _playerScore;

    public static void ResetScore()
    {
        _playerScore = 0;
    }

    public static void KilledEnemy()
    {
        _playerScore += _pointsForEnemy;
    }
}