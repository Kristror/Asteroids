using Configs;
using UnityEngine;
using Utilities;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private float _movementSpeed;
        private float _rotationSpeed;

        private bool _shouldMove;
        private int _rotateDirection;

        private Rigidbody2D _rigidbody;
        private BorderController _borderController;
        private PlayerInputController _playerInputController;
        private ConfigsController _configController;

        [Inject]
        private void Construct(PlayerInputController inputController,ConfigsController configsController, BorderController borderController)
        {
            _borderController = borderController;
            _configController = configsController;
            _playerInputController = inputController;
        }

        private void Start()
        {
            _movementSpeed = _configController.GetPlayerMovementSpeed();
            _rotationSpeed = _configController.GetPlayerRotationSpeed();

            _rigidbody = GetComponent<Rigidbody2D>();

            _borderController.TrackObject(transform);
            _playerInputController.Move += MoveInput;
            _playerInputController.Rotate += RotateInput;
        }

        private void OnDestroy()
        {
            _borderController.StopTrackingObject(transform);
            _playerInputController.Move -= MoveInput;
            _playerInputController.Rotate -= RotateInput;
        }

        private void MoveInput(bool shouldMove)
        {
            _shouldMove = shouldMove;
        }

        private void RotateInput(int rotateDirection)
        {
            _rotateDirection = rotateDirection;
        }


        private void FixedUpdate()
        {
            if (_shouldMove)
            {
                Move();
            }
            if (_rotateDirection != 0)
            {
                Rotate();
            }
        }

        private void Move()
        {
            _rigidbody.AddForce(transform.up * _movementSpeed, ForceMode2D.Force);
        }

        private void Rotate()
        {
            _rigidbody.AddTorque(_rotateDirection * _rotationSpeed, ForceMode2D.Force);
        }
    }
}