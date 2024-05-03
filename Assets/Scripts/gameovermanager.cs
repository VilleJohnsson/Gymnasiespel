using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        Health.OnPlayerDeath += EndGame;
    }

    void OnDisable()
    {
        Health.OnPlayerDeath -= EndGame;
    }

    public void EndGame()
    {
        Debug.Log("Game Over: Player's health reached 0.");
        StartCoroutine(ReloadSceneAfterDelay(2f)); // Reload scene after 2 seconds
    }

    IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
