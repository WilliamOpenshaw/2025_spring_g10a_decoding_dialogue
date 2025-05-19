using UnityEngine;
using UnityEngine.UI;

public class enemyDetectHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image enemyHealth;
    public GameObject GameOverUI;
    //public Image playerHealth;

    public GameObject franceUIFight;

    public GameObject franceFightLevel;
    public GameObject franceUIEndOfFight;
    public GameObject germanyUIFight;
    public GameObject germanyFightLevel;
     public GameObject germanyUIEndOfFight;
    public GameObject sovietUIFight;

     public GameObject sovietFightLevel;
     public GameObject sovietUIEndOfFight;

    public GameObject endScreenUI;
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision Happened");
        if (col.CompareTag("Player"))
        {
            enemyHealth.fillAmount -= 0.1f;
            Debug.Log("Enemy has been hit by player");
            Debug.Log(enemyHealth.fillAmount);
        }
        // if fillamount is less than or equal to 0, go to next level
        if (enemyHealth.fillAmount <= 0 && GameOverUI.activeSelf == false)
        {
            //check what level it is now and open next level UI
            if (franceUIFight.activeSelf == true)
            {
                franceUIFight.SetActive(false);
                franceFightLevel.SetActive(false);
                franceUIEndOfFight.SetActive(true);
            }
            else if (germanyUIFight.activeSelf == true)
            {
                germanyUIFight.SetActive(false);
                germanyFightLevel.SetActive(false);
                germanyUIEndOfFight.SetActive(true);
            }
            else if (sovietUIFight.activeSelf == true)
            {
                sovietUIFight.SetActive(false);
                sovietFightLevel.SetActive(false);
                sovietUIEndOfFight.SetActive(true);
                // Load next level
                // SceneManager.LoadScene("NextLevel");
            }
            Debug.Log("Enemy Defeated");
            // Load next level
            // SceneManager.LoadScene("NextLevel");
        }
    }
}
