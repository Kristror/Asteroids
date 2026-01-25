using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _timeOfLive;
    [SerializeField] private float _speedMovement;

    void Start()
    {
        Destroy(this.gameObject, _timeOfLive);
    }

    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * _speedMovement);
    }
}
