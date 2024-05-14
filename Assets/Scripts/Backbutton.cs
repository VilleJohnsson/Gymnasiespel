using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public int targetSceneIndex = 0; // Index of the scene to load

    // Function to be called when the button is clicked
    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }
}
