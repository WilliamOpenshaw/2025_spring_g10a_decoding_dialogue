using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverCepa : MonoBehaviour
{
    public GameObject france;
    public GameObject germany;
    public GameObject soviet;

    public GameObject fightUIFrance;
    public GameObject fightUIGermany;
    public GameObject fightUISoviet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void gameOver()
    {
        if (france.activeSelf == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            france.SetActive(true);
        }
        germany.SetActive(false);
        soviet.SetActive(false);
    }
}
