using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(0)] private float _movementSpeed;
    private Rigidbody2D _rigidBodyPlayer;

    private Keyboard _keyboard;

    private void Start()
    {
        _rigidBodyPlayer = GetComponent<Rigidbody2D>();
        _keyboard = Keyboard.current;
    }
    

    private void Update()
    {
        Move();
        CheckBorder();
    }   

    private void Move()
    {
        if (_keyboard.wKey.isPressed || _keyboard.upArrowKey.isPressed)
        {
            _rigidBodyPlayer.AddForce((this.transform.up * _movementSpeed), ForceMode2D.Force);
        }
    }
    private void CheckBorder()
    {
        Vector2 newPosition = BorderController.CheckIfObjectOnBorder(transform.position);

        if (newPosition != Vector2.zero) 
        {

            _rigidBodyPlayer.position = newPosition;
        }
    }
}
