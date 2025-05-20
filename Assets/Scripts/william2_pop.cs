using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class william2_pop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float xSize;
    public float ySize;
    public float zSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xSize = gameObject.transform.localScale.x;
        ySize = gameObject.transform.localScale.y;
        zSize = gameObject.transform.localScale.z;
    }

    // This triggers when the mouse exits the area of this script's gameObject
    public void OnPointerExit(PointerEventData eventData2)
    {
        Debug.Log("Sets country back to original size when mouse exits.");
        gameObject.transform.localScale = new Vector3(xSize, ySize, zSize);
    }
    // This triggers when the mouse enters or goes over the area of this script's gameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log sends messages we can read to the console window in Unity
        Debug.Log("Gavin is drinking water.");
        // Multiplies the x, y, and z scale value of the gameObject this script is attached to by 1.5
        // The number is written as " 1.5f " because it is a float,
        // and needs to be written with an f attached to work properly
        gameObject.transform.localScale = new Vector3(xSize* (-2.0f), ySize * 0.5f, zSize * 3.0f);
        //cube1.transform.localScale = new Vector3(sizeX * 1.5f, sizeY * 1.5f, sizeZ * 1.5f);
    }
}
