using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGameCEPA : MonoBehaviour
{
    
    
    public void restartGame()
    {
        // Restart the game by reloading the current scene
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
