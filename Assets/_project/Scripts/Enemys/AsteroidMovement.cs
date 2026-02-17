using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AsteroidMovement : MonoBehaviour
{
    [field:SerializeField, Min(0)] public float AsteroidMovementSpeed {get; private set;}

    private Rigidbody2D _rigidBody;

    public void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void SetMovementSpeed(float speed)
    {
        if( speed > 0) AsteroidMovementSpeed = speed;
    }

    private void Update()
    {
        Move();
        CheckBorder();
    }

    private void Move()
    {
        _rigidBody.AddForce((this.transform.up * AsteroidMovementSpeed), ForceMode2D.Force);
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