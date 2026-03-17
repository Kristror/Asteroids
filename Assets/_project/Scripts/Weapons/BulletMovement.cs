using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _bulletMovementSpeed;

        private Rigidbody2D _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _rigidBody.AddForce(transform.up * _bulletMovementSpeed, ForceMode2D.Force);
        }
    }
}