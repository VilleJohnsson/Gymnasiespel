using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndChecker : MonoBehaviour
{
    public GameObject[] enemies; // Array of enemy GameObjects
    bool allEnemiesDead = false; // Flag to track if all enemies are dead
    bool playerAtEnd = false; // Flag to track if the player is at the end marker
    int previousSceneIndex; // Index of the previous scene

    void Start()
    {
        // Store the index of the current scene
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached the end marker.");
            playerAtEnd = true;
            CheckGameConditions();
        }
        else if (other.CompareTag("Endgame"))
        {
            Debug.Log("Player collided with object tagged as EndGameTag.");
            EndGame();
        }
    }

    void CheckGameConditions()
    {
        // Check if all enemies are dead and the player is at the end marker
        if (allEnemiesDead && playerAtEnd)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over: All conditions met. Player wins!");

        // Load the previous scene
        SceneManager.LoadScene(previousSceneIndex);
    }
}
