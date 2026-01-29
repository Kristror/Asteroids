using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(0)] private float _movementSpeed;
    private Rigidbody2D _rigidBodyPlayer;

    private Keyboard _keyboard;

    void Start()
    {
        _rigidBodyPlayer = GetComponent<Rigidbody2D>();
        _keyboard = Keyboard.current;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_keyboard.wKey.isPressed || _keyboard.upArrowKey.isPressed)
        {
            _rigidBodyPlayer.AddForce((this.transform.up * _movementSpeed), ForceMode2D.Force);
        }
    }
}
