using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class controlReticle : MonoBehaviour
{
     public Gamepad gamepad = Gamepad.current;

     public float right;
     public float left;
     public GameObject startbutton;
     public GameObject buttonbackground;

     public int buttonleft;
     public int buttonright;

     public int buttonup;

     public int buttondown;

     public int cursorlimitUp;
     public int cursorlimitDown;
     public int cursorlimitLeft;
     public int cursorlimitRight;

     //-258 y -415 y
     // -313 265 x

     public int sensativity = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Start()
    {
        sensativity = 5;
        //buttonleft = -224;
        //buttonright = 368;

        //buttonup = -163;

        //buttondown = -334;

        //cursorlimitUp = 432;
        //cursorlimitDown = -432;
        //cursorlimitLeft = -883;
        //cursorlimitRight = 883;
    }

    // Update is called once per frame
    void Update()
    {

        
        if( gameObject.GetComponent<RectTransform>().anchoredPosition.x > buttonleft && 
            gameObject.GetComponent<RectTransform>().anchoredPosition.x < buttonright && 
            gameObject.GetComponent<RectTransform>().anchoredPosition.y < buttonup &&
            gameObject.GetComponent<RectTransform>().anchoredPosition.y > buttondown)
        {
            buttonbackground.SetActive(true);
            if(gamepad.aButton.wasPressedThisFrame)
            {
                startbutton.GetComponent<Button>().onClick.Invoke();
            }
        }
        else
        {
            buttonbackground.SetActive(false);

        }

        if(Gamepad.current == null)
        {
            // do nothing
        }
        else
        {
            if(gamepad.rightStick.right.magnitude > 0 && gameObject.GetComponent<RectTransform>().anchoredPosition.x < 889)
            {
                right = gamepad.rightStick.right.magnitude;
                gameObject.GetComponent<RectTransform>().anchoredPosition = 
                new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x + (gamepad.rightStick.right.magnitude * sensativity), 
                            gameObject.GetComponent<RectTransform>().anchoredPosition.y);
            }
            else if(gamepad.rightStick.left.magnitude > 0 && gameObject.GetComponent<RectTransform>().anchoredPosition.x > -883)
            {
                left = gamepad.rightStick.right.magnitude;
                gameObject.GetComponent<RectTransform>().anchoredPosition = 
                new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x - (gamepad.rightStick.left.magnitude * sensativity), 
                            gameObject.GetComponent<RectTransform>().anchoredPosition.y);
            }
        
       
        
            if(gamepad.rightStick.up.magnitude > 0 && gameObject.GetComponent<RectTransform>().anchoredPosition.y < 432)
            {
                right = gamepad.rightStick.up.magnitude;
                gameObject.GetComponent<RectTransform>().anchoredPosition = 
                new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, 
                            gameObject.GetComponent<RectTransform>().anchoredPosition.y + (gamepad.rightStick.up.magnitude * sensativity));
            }
            else if(gamepad.rightStick.down.magnitude > 0 && gameObject.GetComponent<RectTransform>().anchoredPosition.y > -429)
            {
                left = gamepad.rightStick.down.magnitude;
                gameObject.GetComponent<RectTransform>().anchoredPosition = 
                new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x , 
                            gameObject.GetComponent<RectTransform>().anchoredPosition.y - (gamepad.rightStick.down.magnitude * sensativity));
            }
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(Gamepad.current);
        }
    }
}
