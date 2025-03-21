using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class elsaJump : MonoBehaviour
{


    public float velocity;
    public float timeNow;
    public RectTransform elsaRect;

    public Vector2 ontheGround;
    public Vector2 inTheAir;
    public float jumpProgress;
    public bool up;

    public GameObject olaf1;
    public GameObject olaf2;
    public GameObject olaf3;

    public GameObject boom;

    public RectTransform olaf1Rect;
    public RectTransform olaf2Rect;
    public RectTransform olaf3Rect;

    public moveLeft olafScript1;
    public moveLeft olafScript2;
    public moveLeft olafScript3;

    public int counter;

    public GameObject loseScreen;
    public GameObject winScreen;

    public Image countdown;

    public bool playing;
    // Start is called before the first frame update
    void Start()
    {
        countdown.gameObject.SetActive(true);
        countdown.fillAmount = 0.0f;
        loseScreen.SetActive(false);
        counter = 0;
        playing = true;
        //olafScript.velocity = 13.0f;
        boom.SetActive(false);

        velocity = 5.0f;        
        ontheGround = new Vector2(-694,-400);
        inTheAir = new Vector2(-694,400);
        elsaRect = gameObject.GetComponent<RectTransform>();

        olaf1Rect = olaf1.GetComponent<RectTransform>();
        olaf2Rect = olaf2.GetComponent<RectTransform>();
        olaf3Rect = olaf3.GetComponent<RectTransform>();

        jumpProgress = 0.0f;
        up = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {    
         
        countdown.fillAmount += 0.035f * Time.deltaTime;

        if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && jumpProgress <= 0.0f && playing == true)
        {
            up = true;
        }
        else if(jumpProgress < 1.0f && up == true)
        {
            jumpProgress += 0.025f;
            elsaRect.anchoredPosition = Vector2.Lerp(ontheGround, inTheAir, jumpProgress);
        }
        else if (jumpProgress >= 1.0f && up == true)
        {
            up = false;
        }
        else if (jumpProgress > 0.0f && up == false)
        {
            jumpProgress -= 0.025f;
            elsaRect.anchoredPosition = Vector2.Lerp(ontheGround, inTheAir, jumpProgress);
        }  

        if  ( 
                (
                    (
                        (olaf1Rect.anchoredPosition.x < -670) 
                        &&
                        (olaf1Rect.anchoredPosition.x > -720)
                    ) 
                    ||
                    (
                        (olaf2Rect.anchoredPosition.x < -670) 
                        &&
                        (olaf2Rect.anchoredPosition.x > -720)
                    ) 
                    ||
                    (
                        (olaf3Rect.anchoredPosition.x < -670) 
                        &&
                        (olaf3Rect.anchoredPosition.x > -720)
                    )
                )
                &&
                (elsaRect.anchoredPosition.y < -146)
            )
        {
            boom.SetActive(true);
            olafScript1.velocity = 0.0f;
            olafScript2.velocity = 0.0f;
            olafScript3.velocity = 0.0f;
            playing = false;
        }
        if(playing == false)
        {
            counter += 1;
        }
        if(counter > 80)
        {
            playing = true;
            boom.SetActive(false);
            counter = 0;
            olaf1Rect.anchoredPosition = new Vector2(5571,-452);
            olaf2Rect.anchoredPosition = new Vector2(1018,-427);
            olaf3Rect.anchoredPosition = new Vector2(3462,-392);
            loseScreen.SetActive(true);
            countdown.gameObject.SetActive(false);
        }
        if(countdown.fillAmount > 0.99f && countdown.IsActive() == true)
        {

            winScreen.SetActive(true);
            countdown.gameObject.SetActive(false);
        }
        
    }
}
