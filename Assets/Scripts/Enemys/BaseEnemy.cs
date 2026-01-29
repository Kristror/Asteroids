using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Collision(collision);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Destroy(this.gameObject);
        }
    }

    public abstract void Collision(Collision2D collision);

}
