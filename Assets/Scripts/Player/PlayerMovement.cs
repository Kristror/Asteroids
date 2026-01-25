using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(0)] private float _movementSpeed;
    private Rigidbody2D _rigidBodyPlayer;

    void Start()
    {
        _rigidBodyPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _rigidBodyPlayer.AddForce(this.transform.up * _movementSpeed, ForceMode2D.Force);
        }
    }
}
