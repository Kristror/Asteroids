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

        private Rigidbody2D _rigidBody;
        private BorderController _borderController;
        private PlayerInputController _playerInputController;

        [Inject]
        public void Construct(PlayerInputController inputController, BorderController borderController)
        {
            _borderController = borderController;
            _playerInputController = inputController;


            _borderController.TrackObject(transform);
            _playerInputController.Move += Move;
            _playerInputController.Rotate += Rotate;
        }

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void OnDestroy()
        {

            _borderController.StopTrackingObject(transform);
            _playerInputController.Move -= Move;
            _playerInputController.Rotate -= Rotate;
        }

        private void Move()
        {
            _rigidBody.AddForce(transform.up * _movementSpeed, ForceMode2D.Force);            
        }

        private void Rotate(int direction)
        {
            _rigidBody.AddTorque(_rotationSpeed * direction, ForceMode2D.Force);
        }
    }
}