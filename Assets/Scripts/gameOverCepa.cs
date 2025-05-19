using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverCepa : MonoBehaviour
{
    

    public GameObject UIFrance;
    public GameObject UIGermany;
    public GameObject UISoviet;

    public GameObject mainMenuUI;
    

    public void gameOverReset()
    {
        // france
        if (UIFrance.activeSelf == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            UIFrance.SetActive(true);
            mainMenuUI.SetActive(false);
        }
        // germany
        else if (UIFrance.activeSelf == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            UIGermany.SetActive(true);
            mainMenuUI.SetActive(false);
        }
        // soviet
        else if (UIFrance.activeSelf == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            UISoviet.SetActive(true);
            mainMenuUI.SetActive(false);
        }
        
    }
}
