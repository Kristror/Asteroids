using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Score.KilledEnemy();
            Collision(collision);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Lazer")
        {
            Score.KilledEnemy();
            Destroy(this.gameObject);
        }
    }

    public abstract void Collision(Collider2D collision);

}
