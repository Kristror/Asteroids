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

    private void RotateAtRandomAngle()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    public override void Collision(Collider2D collision) {}

    public void SetSpeed(float speed)
    {
        _asteroidMovement.SetMovementSpeed(speed * _asteroidSpeedMult);
    }
}