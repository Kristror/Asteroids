using UnityEngine;
using Utilities;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _movementSpeed;
        [SerializeField, Min(0)] private float _rotationSpeed;

        private Rigidbody2D _rigidbody;
        private BorderController _borderController;
        private PlayerInputController _playerInputController;

        [Inject]
        private void Construct(PlayerInputController inputController, BorderController borderController)
        {
            _borderController = borderController;
            _playerInputController = inputController;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();


            _borderController.TrackObject(transform);
            _playerInputController.Move += Move;
            _playerInputController.Rotate += Rotate;
        }

        private void OnDestroy()
        {
            _borderController.StopTrackingObject(transform);
            _playerInputController.Move -= Move;
            _playerInputController.Rotate -= Rotate;
        }

        private void Move()
        {
            _rigidbody.AddForce(transform.up * _movementSpeed, ForceMode2D.Force);            
        }

        private void Rotate(int direction)
        {
            _rigidbody.AddTorque(_rotationSpeed * direction, ForceMode2D.Force);
        }
    }
}