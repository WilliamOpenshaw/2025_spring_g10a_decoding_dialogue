using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class mousePop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    //These are three variables created to store values that we want to use
    // We store values in variables so that we can change them and do math with them
    // When something has a name, it is easier to figure
    public float sizeX;
    public float sizeY;
    public float sizeZ;

    public GameObject cube1;
    public void Start()
    {
        sizeX = gameObject.transform.localScale.x;
        sizeY = gameObject.transform.localScale.y;
        sizeZ = gameObject.transform.localScale.z;
    }

    // This triggers when the mouse exits the area of this script's gameObject
    public void OnPointerExit(PointerEventData eventData2)
    {
        Debug.Log("Exton smiles while thinking of embarrasing his classmates.");
        gameObject.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
    }

    // This triggers when the mouse enters or goes over the area of this script's gameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log sends messages we can read to the console window in Unity
        Debug.Log("Gavin is drinking water.");
        // Multiplies the x, y, and z scale value of the gameObject this script is attached to by 1.5
        // The number is written as " 1.5f " because it is a float, 
        // and needs to be written with an f attached to work properly  
        gameObject.transform.localScale = new Vector3(sizeX * 1.5f, sizeY * 1.5f, sizeZ * 1.5f);
        cube1.transform.localScale = new Vector3(sizeX * 1.5f, sizeY * 1.5f, sizeZ * 1.5f);
    }
}
