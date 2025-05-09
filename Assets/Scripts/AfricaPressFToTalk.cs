using UnityEngine;

public class AfricaPressFToTalk : MonoBehaviour
{
    public GameObject speechBubble;
    public bool canStartConversation;
    public GameObject convo1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canStartConversation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canStartConversation == true)
        {
            convo1.SetActive(true);
        }
    }
    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            speechBubble.SetActive(true);
        }
        canStartConversation = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            speechBubble.SetActive(false);
        }
        canStartConversation = false;
    }
}
