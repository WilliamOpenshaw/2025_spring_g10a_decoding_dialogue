
using UnityEngine;
using UnityEngine.UI;

public class chaseTimer : MonoBehaviour
{
    public Image timer;
    public GameObject giveUpUI;
    public GameObject chaseFreeze;
    public GameObject chaseScene;
    public GameObject chaseSceneUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer.fillAmount -= 0.001f;
        if (timer.fillAmount <= 0.001f)
        {
            giveUpUI.SetActive(true);
            chaseFreeze.SetActive(true);
            chaseScene.SetActive(false);
            chaseSceneUI.SetActive(false);
        }
    }
}
