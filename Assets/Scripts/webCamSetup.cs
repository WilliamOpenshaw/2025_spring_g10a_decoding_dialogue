using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webCamSetup : MonoBehaviour
{
    WebCamTexture webcamTexture;
    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice my_device = new WebCamDevice();
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices[i].name);
            my_device = devices[i];
        }
        webcamTexture = new WebCamTexture(devices[0].name);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        webcamTexture.GetPixel(0,0);
        
    }
}
