using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField, Min(1)] private float _timeOfLive;
    [SerializeField, Min(0)] private float _speedMovement;

    void Start()
    {
        Destroy(this.gameObject, _timeOfLive);
    }

    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * _speedMovement);
    }
}
