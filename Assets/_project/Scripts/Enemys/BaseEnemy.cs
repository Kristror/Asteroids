using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BulletCollision>(out _))
        {
            ScoreController.KilledEnemy();
            Collision(collision);
            Destroy(this.gameObject);
        }
        if (collision.TryGetComponent<Lazer>(out _))
        {
            ScoreController.KilledEnemy();
            Destroy(this.gameObject);
        }
    }

    public virtual void Collision(Collider2D collision) { }

}
