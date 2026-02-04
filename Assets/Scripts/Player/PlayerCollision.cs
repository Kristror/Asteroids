using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollision : MonoBehaviour
{
    private Collider2D _colliderPlayer;

    private bool _isDead;

    public bool isPlayerDead => _isDead;

    void Start()
    {
        _colliderPlayer = GetComponent<Collider2D>();
        _isDead  = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _isDead = true;
            TimeController.StopTime();
        }
    }
}
