using UnityEngine;
using Utilites;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _movementSpeed;
        [SerializeField, Min(0)] private float _rotationSpeed;

        private Rigidbody2D _rigidBodyPlayer;
        private BorderController _borderController;

        private void Start()
        {
            _rigidBodyPlayer = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CheckBorder();
        }

        public void SetDependencies(PlayerInputController inputController,BorderController borderController)
        {
            _borderController = borderController;

            inputController.Move += Move;
            inputController.Rotate += Rotate;
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