using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRotation : MonoBehaviour
{
    [SerializeField, Min(0)] private float _rotationSpeed;
    private Rigidbody2D _rigidBodyPlayer;
    void Start()
    {
        _rigidBodyPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _rigidBodyPlayer.AddTorque(_rotationSpeed,ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _rigidBodyPlayer.AddTorque((_rotationSpeed * -1), ForceMode2D.Force);
        }
    }
}
