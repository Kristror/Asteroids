using UnityEngine;

public class SmallAsteroid : BaseEnemy
{

    [SerializeField] private AsteroidMovement _asteroidMovement;
    [SerializeField] private float _asteroidSpeedMult;

    public override void Collision(Collision2D collision)
    {
    }

    public void Created(float speed)
    {
        _asteroidMovement.SetMovementSpeed(speed * _asteroidSpeedMult);
        this.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }
}