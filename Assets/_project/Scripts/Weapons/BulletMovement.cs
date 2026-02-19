using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMovement : MonoBehaviour
{
    [SerializeField, Min(1)] private float _timeToLive;
    [SerializeField, Min(0)] private float _bulletMovementSpeed;

    private Rigidbody2D _rigidBody;
    private void Update()
    {
        Move();
    }

    public void Shoot(Transform bulletStartPosition)
    {
        transform.position = bulletStartPosition.position;
        transform.rotation = bulletStartPosition.rotation;

        _rigidBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _timeToLive);
    }    

    private void Move()
    {
        _rigidBody.AddForce(transform.up * _bulletMovementSpeed, ForceMode2D.Force);
    }
}
