using UnityEngine;

public class AfricaPressFToTalk : MonoBehaviour
{
    public GameObject speechBubble;
    public bool canStartConversation;
    public GameObject convo1;
    public GameObject line0;
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;
    public GameObject line4;
    public GameObject line5;
    public GameObject line6;
    public GameObject line7;
    public GameObject line8;
    public GameObject line9;
    public GameObject line10;
    public GameObject line11;
    public GameObject line12;
    public GameObject line13;
    public int conversationNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canStartConversation = false;
        conversationNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Conversation 1
        if (Input.GetKeyDown(KeyCode.F) &&
            canStartConversation == true &&
            conversationNumber == 1)
        {
            convo1.SetActive(true);
            line0.SetActive(true);
            line1.SetActive(false);
            line2.SetActive(false);
            line3.SetActive(false);
            line4.SetActive(false);
            line5.SetActive(false);
            line6.SetActive(false);
            line7.SetActive(false);
            line8.SetActive(false);
            line9.SetActive(false);
            line10.SetActive(false);
            line11.SetActive(false);
            line12.SetActive(false);
            line13.SetActive(false);
        }

        // Conversation 2
        if (Input.GetKeyDown(KeyCode.F) &&
            canStartConversation == true &&
            conversationNumber == 2)
        {
            convo1.SetActive(true);
            line1.SetActive(true);
            line0.SetActive(true);
            line1.SetActive(false);
            line2.SetActive(false);
            line3.SetActive(false);
            line4.SetActive(false);
            line5.SetActive(false);
            line6.SetActive(false);
            line7.SetActive(false);
            line8.SetActive(false);
            line9.SetActive(false);
            line10.SetActive(false);
            line11.SetActive(false);
            line12.SetActive(false);
            line13.SetActive(false);
        }
    }
    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            speechBubble.SetActive(true);
        }
        canStartConversation = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            speechBubble.SetActive(false);
        }
        canStartConversation = false;
    }
    public void AddOneToConversation()
    {
        conversationNumber += 1;
    }
}
