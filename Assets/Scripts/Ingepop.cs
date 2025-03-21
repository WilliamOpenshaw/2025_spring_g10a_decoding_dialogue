using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ingepop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{

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
        Debug.Log("The cursor entered the selectable UI element.");

        gameObject.transform.localScale = new Vector3(sizeX * 1.25f, sizeY * 1.25f, sizeZ * 1.25f);
    }


}