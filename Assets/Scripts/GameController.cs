using UnityEngine;


public class GameController : MonoBehaviour
{
    [SerializeField] GameObject _prefabPlayer;
    [SerializeField] GameObject _prefabUI;

    private void Awake()
    {
        GameObject.Instantiate(_prefabPlayer);

        Score.ResetScore();
    }
}