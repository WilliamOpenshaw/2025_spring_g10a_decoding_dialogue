using UnityEngine;
using UnityEngine.SceneManagement;

public class popResetChase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    public void ResetChase()
    {
         SceneManager.LoadScene("pop chasing start 0.0.7");
    }
}
