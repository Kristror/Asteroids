using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletCollision : MonoBehaviour
{
    private Collider2D _colliderBullet;

    void Start()
    {
        _colliderBullet = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}