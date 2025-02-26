using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonSensor : MonoBehaviour
{
    public Button redButton;
    public Button blueButton;
    public Button greenButton;
    public webCamToRawImage webCamScript;
    public int counter;  
    

    void Start()
    {
        counter = 0; 
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(webCamScript.red == true) 
        {      
            counter += 1;
        }
        else if(webCamScript.green == true) 
        {      
            counter += 1;
        }
        else if(webCamScript.blue == true) 
        {      
            counter += 1;
        }
        else
        {
            counter = 0;
        }

        if(webCamScript.red == true && counter > 60) 
        {      
            redButton.onClick.Invoke();
            counter = 0;
        }
        else if(webCamScript.green == true && counter > 60) 
        {      
            greenButton.onClick.Invoke();
            counter = 0;
        }
        else if(webCamScript.blue == true && counter > 60) 
        {      
            blueButton.onClick.Invoke();
            counter = 0;
        }

    }

}
