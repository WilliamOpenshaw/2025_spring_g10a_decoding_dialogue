using UnityEngine;

public class AfricaPressFToTalk : MonoBehaviour
{
    public GameObject speechBubble;
    public bool canStartConversation;
    public GameObject convo1;
    public GameObject convo2;
    public GameObject convo3;
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
    public GameObject line14; 
    public int conversationNumber;
    public bool gotAllItems;
    public GameObject lionHeart;
    public GameObject elephantTusk;
    public GameObject rhinoDust; 
    public GameObject hyenaFur; 
    public GameObject lionHeartGOT;
    public GameObject elephantTuskGOT;
    public GameObject rhinoDustGOT; 
    public GameObject hyenaFurGOT; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canStartConversation = false;
        conversationNumber = 1;
        gotAllItems = false;
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
            line14.SetActive(false);
            AddOneToConversation();
        }

        // Conversation 2
        else if (Input.GetKeyDown(KeyCode.F) &&
            canStartConversation == true &&
            conversationNumber == 2)
        {
            convo2.SetActive(true);
            AddOneToConversation();
        }

        else if (Input.GetKeyDown(KeyCode.F) &&
            canStartConversation == true &&
            conversationNumber == 3 &&
            speechBubble.activeSelf == true &&
            gotAllItems == true)
        {
            convo3.SetActive(true);
        }




    }
    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (conversationNumber < 3)
            {
                speechBubble.SetActive(true);
            }
            else if (conversationNumber > 2 && gotAllItems == true)
            {
                speechBubble.SetActive(true);
            }
        }
        canStartConversation = true;
        if (col.CompareTag("Player") 
            &&  hyenaFurGOT.activeSelf ==true 
            &&  lionHeartGOT.activeSelf ==true
            &&  rhinoDustGOT.activeSelf ==true
            &&  elephantTuskGOT.activeSelf ==true
            )
        {
            gotAllItems = true;
        }
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
