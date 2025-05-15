using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class press_B_To_Stert : MonoBehaviour
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
            if(gamepad.bButton.wasPressedThisFrame || Input.GetKeyDown(KeyCode.A))
            {
                gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
       
        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(Gamepad.current);
        }
    }
}
