using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class kikiTextSwitch1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject mainMenu;
    public GameObject gettingStarted;
    public Gamepad gamepad = Gamepad.current;
    void Start()
    {
        text1.SetActive(true);
        text2.SetActive(false);
        text3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || gamepad.aButton.wasPressedThisFrame)
        {
            if(text1.activeSelf)
            {
                text1.SetActive(false);
                text2.SetActive(true);
                text3.SetActive(false);
            }
            else if (text2.activeSelf)
            {
                text1.SetActive(false);
                text2.SetActive(false);
                text3.SetActive(true);
            }
            else if (text3.activeSelf)
            {
                text1.SetActive(true);
                text2.SetActive(false);
                text3.SetActive(false);

                gettingStarted.SetActive(true);

                mainMenu.SetActive(false);
            }
        }
    }
}
