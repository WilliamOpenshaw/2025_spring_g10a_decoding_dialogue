using UnityEngine;
using UnityEngine.SceneManagement;

public class restartKiki : MonoBehaviour
{
    

    // Update is called once per frame
    public void RestartKikiScene()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }
}
