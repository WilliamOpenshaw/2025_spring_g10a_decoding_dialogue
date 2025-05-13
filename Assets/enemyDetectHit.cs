using UnityEngine;
using UnityEngine.UI;

public class enemyDetectHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image enemyHealth;
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision Happened");
        if (col.CompareTag("Player"))
        {
            enemyHealth.fillAmount -= 0.1f;
            Debug.Log("Hit Player");
            Debug.Log(enemyHealth.fillAmount);
        }
    }
}
