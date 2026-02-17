using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UFOMovement : MonoBehaviour
{
    [SerializeField, Min(0)] private float _ufoMovementSpeed;

    private Rigidbody2D _rigidbody;

    private Transform _playerObject;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetPlayer(GameObject playerObject)
    {
        _playerObject = playerObject.transform;
    }


    private void Update()
    {
        MoveToPlayer();
        CheckBorder();
    }

    private void MoveToPlayer()
    {
        Vector2 direction = (_playerObject.position - transform.position).normalized;

        _rigidbody.AddForce(direction * _ufoMovementSpeed, ForceMode2D.Force);
    }

    private void CheckBorder()
    {
        Vector2 newPosition = BorderController.CheckIfObjectOnBorder(transform.position);

        if (newPosition != Vector2.zero)
        {
            _rigidbody.position = newPosition;
        }
    }
}