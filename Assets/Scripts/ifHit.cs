using UnityEngine;

public class ifHit : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject chasingGameWorld;
    public GameObject chasingFreezeframe;
    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            gameOverUI.SetActive(true);
            chasingFreezeframe.SetActive(true);
            chasingGameWorld.SetActive(false);
        }
    }
}
