using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class kiki_AnswerA : MonoBehaviour
{
     public Gamepad gamepad = Gamepad.current;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if(Gamepad.current == null)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
        else
        {
            if(gamepad.aButton.wasPressedThisFrame || Input.GetKeyDown(KeyCode.A))
            {
                gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
