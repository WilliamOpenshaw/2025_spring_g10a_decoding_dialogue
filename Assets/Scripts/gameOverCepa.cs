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
            SceneManager.LoadScene("cepa 0.0.17 -  france fight");
            
            UIFrance.SetActive(true);
            mainMenuUI.SetActive(false);
        }
        // germany
        else if (UIGermany.activeSelf == true)
        {
            SceneManager.LoadScene("cepa 0.0.17 - germany fight");
            
            UIGermany.SetActive(true);
            mainMenuUI.SetActive(false);
        }
        // soviet
        else if (UISoviet.activeSelf == true)
        {
            SceneManager.LoadScene("cepa 0.0.17 - soviet fight");
            
            UISoviet.SetActive(true);
            mainMenuUI.SetActive(false);
        }
        
    }
}
