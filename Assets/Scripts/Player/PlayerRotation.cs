using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRotation : MonoBehaviour
{
    [SerializeField, Min(0)] private float _rotationSpeed;
    private Rigidbody2D _rigidBodyPlayer;

    private Keyboard _keyboard;

    private void Start()
    {
        _rigidBodyPlayer = GetComponent<Rigidbody2D>();
        _keyboard = Keyboard.current;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (_keyboard.aKey.isPressed || _keyboard.leftArrowKey.isPressed)
        {
            _rigidBodyPlayer.AddTorque(_rotationSpeed, ForceMode2D.Force);
        }
        if (_keyboard.dKey.isPressed || _keyboard.rightArrowKey.isPressed)
        {
            _rigidBodyPlayer.AddTorque((_rotationSpeed * -1), ForceMode2D.Force);
        }
    }
}
