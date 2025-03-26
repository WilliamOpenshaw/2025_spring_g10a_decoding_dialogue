using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class jennifer-pop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float xSize;
    public float YSize;
    public float ZSize;
    void Start()
    {
        xSize = gameObject.transform.localScale.x;
        YSize = gameObject.transform.localScale.y;
        ZSize = gameObject.transform.localScale.z;
    }

    void Update()
    {
       
    }

   public void OnPointerExit(PointerEventData eventData2)
    {
        Debug.Log("Exton farts while thinking of embarrasing his classmates.");
        gameObject.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Zachary likes farting."); 
        gameObject.transform.localScale = new Vector3(sizeX * 1.5f, sizeY * 1.5f, sizeZ * 1.5f);
        cube1.transform.localScale = new Vector3(sizeX * 1.5f, sizeY * 1.5f, sizeZ * 1.5f);
    }
}
