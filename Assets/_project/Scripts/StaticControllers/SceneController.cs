using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneController
{
    public static void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}