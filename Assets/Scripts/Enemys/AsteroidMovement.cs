using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField, Min(1)] private float _asteroidMovementSpeed;

    public float AsteroidSpeed => _asteroidMovementSpeed;
    
    public void SetMovementSpeed(float speed)
    {
        _asteroidMovementSpeed = speed;
    }

    private void Update()
    {
        Move();
        CheckBorder();
    }

    private void Move()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * _asteroidMovementSpeed);
    }

    private void CheckBorder()
    {
        Vector2 newPosition = BorderController.CheckIfObjectOnBorder(transform.position);

        if (newPosition != Vector2.zero)
        {

            transform.position = newPosition;
        }
    }
}