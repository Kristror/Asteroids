using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private float _asteroidMovementSpeed;

    public float AsteroidSpeed => _asteroidMovementSpeed;
    
    public void SetMovementSpeed(float speed)
    {
        _asteroidMovementSpeed = speed;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}