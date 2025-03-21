using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countQuestions : MonoBehaviour
{
    
    public int wrongAnswerCount;
    public int rightAnswerCount;
    //public int questionsAnswered;
    public GameObject loseScreen;
    public GameObject winScreen;
    public Image hydrahealth1;
    public Image humanhealth1;
    public Image hydrahealth2;
    public Image humanhealth2;
    public Image hydrahealth3;
    public Image humanhealth3;
    public int counter;

    public GameObject story;
    // Start is called before the first frame update
    void Start()
    {
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        //questionsAnswered = 0;
        wrongAnswerCount = 0;
        rightAnswerCount = 0;
        hydrahealth1.fillAmount = 1.0f;
        humanhealth1.fillAmount = 1.0f;
        hydrahealth2.fillAmount = 1.0f;
        humanhealth2.fillAmount = 1.0f;
        hydrahealth3.fillAmount = 1.0f;
        humanhealth3.fillAmount = 1.0f;
        counter = 0;
        //questionsAnswered = 0;
    }

 

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += 1;
        if(wrongAnswerCount >= 2)
        {
            loseScreen.SetActive(true);
            //questionsAnswered = 0;
            wrongAnswerCount = 0;
            rightAnswerCount = 0;
            hydrahealth1.fillAmount = 1.0f;
            humanhealth1.fillAmount = 1.0f;
            hydrahealth2.fillAmount = 1.0f;
            humanhealth2.fillAmount = 1.0f;
            hydrahealth3.fillAmount = 1.0f;
            humanhealth3.fillAmount = 1.0f;

        }
        if(rightAnswerCount >= 3)
        {
            winScreen.SetActive(true);
            //questionsAnswered = 0;
            wrongAnswerCount = 0;
            rightAnswerCount = 0;
            hydrahealth1.fillAmount = 1.0f;
            humanhealth1.fillAmount = 1.0f;
            hydrahealth2.fillAmount = 1.0f;
            humanhealth2.fillAmount = 1.0f;
            //hydrahealth3.fillAmount = 1.0f;
            humanhealth3.fillAmount = 1.0f;
        }
        if(story.activeSelf == true)
        {
            hydrahealth1.fillAmount = 1.0f;
            humanhealth1.fillAmount = 1.0f;
            hydrahealth2.fillAmount = 1.0f;
            humanhealth2.fillAmount = 1.0f;
            hydrahealth3.fillAmount = 1.0f;
            humanhealth3.fillAmount = 1.0f;
        }
    }
    public void WrongAnswer()
    {
        if (counter > 40)
        {
          counter = 0;
        humanhealth1.fillAmount -= 0.5f;
        humanhealth2.fillAmount -= 0.5f;
        humanhealth3.fillAmount -= 0.5f;
        wrongAnswerCount += 1;
        //questionsAnswered += 1;  
        }
        
    }
    public void RightAnswer()
    {
        if (counter > 40)
        {
          counter = 0;
        hydrahealth1.fillAmount -= 0.3f;
        hydrahealth2.fillAmount -= 0.3f;
        hydrahealth3.fillAmount -= 0.3f;
        rightAnswerCount += 1;
        //questionsAnswered += 1;
        }  
     }
        
}
