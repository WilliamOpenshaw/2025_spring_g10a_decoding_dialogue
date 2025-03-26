using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class hans : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    public void OnPointerExit(PointerEventData eventData2)
    {
        Debug.Log("The cursor EXITED the selectable UI element.");
        gameObject.transform.localScale = new Vector3(xSize, ySize, zSize);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        gameObject.transform.localScale = new Vector3(xSize * 3.0f, ySize * 2.5f, zSize * 1.5f);
            
    }
}