using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletCollision : MonoBehaviour
{
    private Collider2D _colliderBullet;

    private void Start()
    {
        _colliderBullet = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<BaseEnemy>(out _))
        {
            Destroy(this.gameObject);
        }
    }
}