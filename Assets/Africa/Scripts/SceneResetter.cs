using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneResetter : MonoBehaviour
{
    public void ResetCurrentScene()
    {
        // Get the name of the current scene
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Load the current scene
        SceneManager.LoadScene(currentSceneName);
    }
}
