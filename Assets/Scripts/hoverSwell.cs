using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required to change UI elements in Unity
using UnityEngine.EventSystems; // Required when using Event data.


//This is our script class
public class hoverSwell : MonoBehaviour, IPointerEnterHandler,  IPointerExitHandler //required for mouse over effects
{   
    //create variable for sizeX
    public float sizeX;
    //create variable for sizeX
    public float sizeY;
    //create variable for sizeX
    public float sizeZ;

    //Do this once when program starts
    public void Start()
    {   
        //save starting x size
        sizeX = gameObject.transform.localScale.x;
        //save starting y size
        sizeY = gameObject.transform.localScale.y;
        //save starting z size
        sizeZ = gameObject.transform.localScale.z;
    }

    //Do this when the cursor exits the rect area of this selectable UI object.
    public void OnPointerExit(PointerEventData eventData2)
    {
        //send a message to console if exit
        Debug.Log("The cursor EXITED the selectable UI element.");

        //double the size of this object that the script is attached to
        gameObject.transform.localScale = new Vector3(  sizeX, sizeY, sizeZ );
    }

    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        //send a message to console if enter
        Debug.Log("The cursor entered the selectable UI element.");
        
        //double the size of this object that the script is attached to
        gameObject.transform.localScale = new Vector3(  sizeX * 2, sizeY * 2 , sizeZ * 2 );
    }

    
}

