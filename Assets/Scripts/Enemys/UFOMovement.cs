using UnityEngine;


public class UFOMovement : MonoBehaviour
{
    [SerializeField, Min(1)] private float _ufoMovementSpeed;
    private Rigidbody2D _rigidbodyUFO;

    private GameObject _playerObject;

    private void Start()
    {
        _rigidbodyUFO = GetComponent<Rigidbody2D>();
    }

    public void SetPlayer(GameObject playerObject)
    {
        _playerObject = playerObject;
    }


    private void Update()
    {
        MoveToPlayer();
        CheckBorder();
    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position,_playerObject.transform.position, _ufoMovementSpeed * Time.deltaTime);
    }

    private void CheckBorder()
    {
        Vector2 newPosition = BorderController.CheckIfObjectOnBorder(transform.position);

        if (newPosition != Vector2.zero)
        {

            transform.position = newPosition;
        }
    }
}