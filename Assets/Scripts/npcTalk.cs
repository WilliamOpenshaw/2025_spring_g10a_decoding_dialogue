using UnityEngine;

public class npcTalk : MonoBehaviour
{
    public GameObject triggerTextBubble;
    public GameObject conversationBubble;

    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // trigger off
        triggerTextBubble.SetActive(false);
        conversationBubble.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) < 5)
        {

            if (conversationBubble.activeSelf == false)
            {
                triggerTextBubble.SetActive(true);
            }
            else if (conversationBubble.activeSelf == true)
            {
                triggerTextBubble.SetActive(false);
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                triggerTextBubble.SetActive(false);
                conversationBubble.SetActive(true);
            }
        }
        else{
            triggerTextBubble.SetActive(false);
        }
    }
}
