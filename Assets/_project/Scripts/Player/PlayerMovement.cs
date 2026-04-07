using UnityEngine;
using Utilites;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _movementSpeed;
        [SerializeField, Min(0)] private float _rotationSpeed;

        private Rigidbody2D _rigidBodyPlayer;
        private BorderController _borderController;
        private PlayerInputController _playerInputController;

        [Inject]
        public void Construct(PlayerInputController inputController, BorderController borderController)
        {
            _borderController = borderController;
            _playerInputController = inputController;

            _playerInputController.Move += Move;
            _playerInputController.Rotate += Rotate;
        }

        private void Start()
        {
            _rigidBodyPlayer = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CheckBorder();
        }

        private void OnDestroy()
        {
            _playerInputController.Move -= Move;
            _playerInputController.Rotate -= Rotate;
        }

        private void Move()
        {
            _rigidBodyPlayer.AddForce(transform.up * _movementSpeed, ForceMode2D.Force);            
        }

        private void Rotate(int direction)
        {
            _rigidBodyPlayer.AddTorque(_rotationSpeed * direction, ForceMode2D.Force);
        }

        private void CheckBorder()
        {
            Vector2 newPosition = _borderController.CheckIfObjectOnBorder(transform.position);

            if (newPosition != Vector2.zero)
            {

                _rigidBodyPlayer.position = newPosition;
            }
        }
    }
}