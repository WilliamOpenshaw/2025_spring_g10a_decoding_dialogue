using UnityEngine;
using System.Collections;
using UnityEngine.Video;

public class kiki_ending_video_script : MonoBehaviour
{
    
    public GameObject endVideo;
    public GameObject restartScreen;
    public bool videoStarted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        videoStarted = false;
    }

    public IEnumerator showRestartScreen()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(1.0f);
        print("WaitAndPrint " + Time.time);
        endVideo.SetActive(false);
        restartScreen.SetActive(true);
    }

    public void Update()
    {
        if (gameObject.GetComponent<VideoPlayer>().isPlaying == true && videoStarted == false)
        {
            videoStarted = true;
        }
        //print("Starting " + Time.time);
        if (gameObject.GetComponent<VideoPlayer>().isPlaying == false && videoStarted == true)
        {
            StartCoroutine(showRestartScreen());
        }
        // Start function WaitAndPrint as a coroutine
        
        //print("Done " + Time.time);
    }
}
