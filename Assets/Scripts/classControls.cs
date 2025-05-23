using UnityEngine;

public class classControls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if press y then quit application
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Application.Quit();
        }
        // if press question mark the reload current scene
        if (Input.GetKeyDown(KeyCode.Question))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        
    }
}
