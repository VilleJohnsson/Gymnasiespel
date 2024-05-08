using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        // Load the next scene (assuming it's the second scene in the build settings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
