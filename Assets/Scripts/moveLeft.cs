using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{

    public RectTransform rect;

    public float velocity;
    
    // Start is called before the first frame update
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        velocity = 13.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity += 0.1f * Time.deltaTime; 
        //olaf1RB.MovePosition(olaf1RB.position + velocity * Time.fixedDeltaTime);
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - velocity,rect.anchoredPosition.y);

        if(rect.anchoredPosition.x < -1128)
        {
            rect.anchoredPosition = new Vector2(Random.Range(5000.0f, 6000.0f),rect.anchoredPosition.y);
        }
        
    }
}


/*
////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openLink : MonoBehaviour
{
    // Start is called before the first frame update
    public void openLinkURL()
    {
        Application.OpenURL("https://trinket.io/python/ad7c33fdd9de");
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////////


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

*/