using UnityEngine;
using UnityEngine.SceneManagement;

public class replayPathOfPeace : MonoBehaviour
{
    
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
