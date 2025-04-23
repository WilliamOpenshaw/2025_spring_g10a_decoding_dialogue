using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkToArticle : MonoBehaviour
{
    public string link;
    // Start is called before the first frame update
    public void openLinkURL()
    {
        Application.OpenURL(link);
    }
}
