using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class mousePop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public float sizeX;
    public float sizeY;
    public float sizeZ;
    public void Start()
    {
        sizeX = gameObject.transform.localScale.x;
        sizeY = gameObject.transform.localScale.y;
        sizeZ = gameObject.transform.localScale.z;
    }

    public void OnPointerExit(PointerEventData eventData2)
    {
        Debug.Log("The cursor EXITED the selectable UI element.");
        gameObject.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.log("The cursor entered the selectable UI element");
        gameObject.transform.localScale = new Vector3(sizeX * (-2.0f), sizeY * 0.5f, sizeZ * 3.0f);
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }
}