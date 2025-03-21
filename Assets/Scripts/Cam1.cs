using UnityEngine;
using UnityEngine.UI; // Required for UI elements (if using RawImage)

public class CameraFeed : MonoBehaviour
{
    public RawImage display; // For UI RawImage display
    public Renderer displayRenderer; // For 3D object display
    private WebCamTexture webcamTexture;

    void Start()
    {
        // Check if cameras are available
        if (WebCamTexture.devices.Length > 0)
        {
            // Use the first camera
            webcamTexture = new WebCamTexture(WebCamTexture.devices[0].name);

            // Assign the texture to the appropriate object
            if (display != null)
                display.texture = webcamTexture; // For UI
            if (displayRenderer != null)
                displayRenderer.material.mainTexture = webcamTexture; // For 3D

            // Start the camera feed
            webcamTexture.Play();
        }
        else
        {
            Debug.LogError("No webcam detected!");
        }
    }

    void OnDestroy()
    {
        // Stop the camera feed when the object is destroyed
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
        }
    }
    
}

