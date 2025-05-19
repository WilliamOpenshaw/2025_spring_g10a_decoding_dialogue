using UnityEngine;
using UnityEngine.UI;

public class playerdetecthit : MonoBehaviour
{
     // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image playerHealth;

    public GameObject franceUIEndOfFight;
    public GameObject germanyUIEndOfFight;
    public GameObject sovietUIEndOfFight;

    public GameObject GameOverUI;
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision Happened");
        if (col.CompareTag("Enemy"))
        {
            playerHealth.fillAmount -= 0.1f;
            Debug.Log("Player has been hit by Enemy");
            Debug.Log(playerHealth.fillAmount);
        }
        // if fillamount is less than or equal to 0, go to game over screen
        if (playerHealth.fillAmount <= 0 && GameOverUI.activeSelf == false && franceUIEndOfFight.activeSelf == false && germanyUIEndOfFight.activeSelf == false && sovietUIEndOfFight.activeSelf == false)        
        {
            Debug.Log("Game Over");
            GameOverUI.SetActive(true);
            // Load game over scene
            // SceneManager.LoadScene("GameOver");
        }
    }
}
