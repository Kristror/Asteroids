using UnityEngine;

[RequireComponent(typeof(AsteroidMovement))]
public class SmallAsteroid : BaseEnemy
{
    [SerializeField, Min(1)] private float _asteroidSpeedMult;

    private AsteroidMovement _asteroidMovement;

    private void Awake()
    {
        _asteroidMovement = GetComponent<AsteroidMovement>();
        RotateAtRandomAngle();
    }
    public void SetSpeed(float speed)
    {
        _asteroidMovement.SetMovementSpeed(speed * _asteroidSpeedMult);
    }

    private void RotateAtRandomAngle()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    protected override void Collision() {}    
}