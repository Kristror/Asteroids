using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField, Min(1)] private float _timeToLive;
    [SerializeField, Min(0)] private float _speedMovement;

    private void Start()
    {
        Destroy(this.gameObject, _timeToLive);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * _speedMovement);
    }
}
