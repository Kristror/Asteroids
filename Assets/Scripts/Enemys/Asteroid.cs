using UnityEngine;

public class Asteroid : BaseEnemy
{
    [SerializeField] private GameObject _smallAsteroid;
    [SerializeField] private AsteroidMovement _asteroidMovement;
    [SerializeField] private int _amountOfpieces;

    private float _asteroidSpeed;

    private void Start()
    {
        _asteroidSpeed = _asteroidMovement.AsteroidSpeed;
    }

    public override void Collision(Collider2D collision)
    {
        CreateSmallAsteroids(_amountOfpieces);
    }

    private void CreateSmallAsteroids(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject smallAsteroid = GameObject.Instantiate(_smallAsteroid, this.transform.position, Quaternion.identity);
            smallAsteroid.transform.position = new Vector2(smallAsteroid.transform.position.x + Random.Range(-0.1f, 0.1f),
                smallAsteroid.transform.position.y + Random.Range(-0.1f, 0.1f)); 
            smallAsteroid.GetComponent<SmallAsteroid>().Created(_asteroidSpeed);
        }
    }    
}
