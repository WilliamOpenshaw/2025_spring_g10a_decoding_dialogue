using UnityEngine;

public class ifAnimDoneThenNext : MonoBehaviour
{
    public GameObject animationObject;
    public Animation anim;

    //public GameObject chaseGame;
    //public GameObject chaseGameUI;

    public GameObject afterTakeSpeechbubble;

    public bool started;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = animationObject.GetComponent<Animation>();
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (started == false && anim.isPlaying == true)
        {
            started = true;
        }
        else if (started == true && anim.isPlaying == false)
        {
            //animationObject.SetActive(false);
            //chaseGame.SetActive(true);
            //chaseGameUI.SetActive(true);
            afterTakeSpeechbubble.SetActive(true);
        }
    }
}
