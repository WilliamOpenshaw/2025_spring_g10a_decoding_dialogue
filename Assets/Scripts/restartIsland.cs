using UnityEngine;
using UnityEngine.SceneManagement;

public class restartIsland : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartIslandGame()
    {
        // This function is called when the button is clicked
        // It reloads the current scene, effectively restarting the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
