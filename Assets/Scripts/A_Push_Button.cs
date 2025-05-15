using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class A_Push_Button : MonoBehaviour
{
    public Gamepad gamepad = Gamepad.current;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //var gamepad = Gamepad.current;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamepad.aButton.wasPressedThisFrame || Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}
