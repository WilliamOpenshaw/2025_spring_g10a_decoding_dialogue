using UnityEngine;

public class nextLocation : MonoBehaviour
{
    public GameObject nextLocationObject;
    public GameObject currentLocationObject;
    public GameObject player;
    public bool animationTriggered;

    public bool isAnimationPlaying;
    void Start()
    {
        nextLocationObject.SetActive(false);
        currentLocationObject.SetActive(true);
        player.SetActive(true);
        animationTriggered = false;
    }
    void Update()
    {
        isAnimationPlaying = currentLocationObject.GetComponent<Animation>().isPlaying;

        if(currentLocationObject.GetComponent<Animation>().isPlaying == true && animationTriggered == false)
        {
            animationTriggered = true;
            Debug.Log("animation started");
        }
        else if(animationTriggered == true && currentLocationObject.GetComponent<Animation>().isPlaying == false)
        {            
            nextLocationObject.SetActive(true);
            Debug.Log("Next is Active, animation done");
            
        }
        if(nextLocationObject.activeSelf == true)
        {
            currentLocationObject.SetActive(false);
            animationTriggered = false;
            Debug.Log("Original is Off");
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision Happened");
        if (col.CompareTag("Player"))
        {
            //set currentLocationObject animation clip to fade out animation clip
            currentLocationObject.GetComponent<Animation>().clip = currentLocationObject.GetComponent<Animation>().GetClip("little prince time travel fade out");
            currentLocationObject.GetComponent<Animation>().Play("little prince time travel fade out");
            player.SetActive(false);
        }       
        
        
    }
}
