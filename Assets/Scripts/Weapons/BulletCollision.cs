using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletCollision : MonoBehaviour
{
    private Collider2D _colliderBullet;

    void Start()
    {
        _colliderBullet = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}