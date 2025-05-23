using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class kiki_AnswerX : MonoBehaviour
{
     public Gamepad gamepad = Gamepad.current;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if(Gamepad.current == null)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
        else
        {
            if(gamepad.xButton.wasPressedThisFrame || Input.GetKeyDown(KeyCode.X))
            {
                gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
