using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollision : MonoBehaviour
{
    private Collider2D _colliderPlayer;

    public bool IsPlayerDead { get; private set; }

    private void Start()
    {
        _colliderPlayer = GetComponent<Collider2D>();
        IsPlayerDead  = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BaseEnemy> (out _))
        {
            IsPlayerDead = true;
            TimeController.StopTime();
        }
    }
}
