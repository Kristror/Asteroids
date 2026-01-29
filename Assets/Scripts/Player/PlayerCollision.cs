using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollision : MonoBehaviour
{
    private Collider2D _colliderPlayer;

    void Start()
    {
        _colliderPlayer = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //обработка смерти
        }
    }
}
