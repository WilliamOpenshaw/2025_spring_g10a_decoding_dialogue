using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControllerFlies : MonoBehaviour
{
    public GameObject olaf1;
    public Rigidbody2D olaf1RB;
    public GameObject targetGoal;

    public float velocity;

    public GameObject elsa;

    public RectTransform o1rect;
    public RectTransform elsaRect;

    public Vector2 ontheGround;
    public Vector2 inTheAir;
    // Start is called before the first frame update
    void Start()
    {
        olaf1RB = olaf1.GetComponent<Rigidbody2D>();
        velocity = 5.0f;
        o1rect = olaf1.GetComponent<RectTransform>();
        ontheGround = new Vector2(-643,-357);
        inTheAir = new Vector2(-643,48);
        elsaRect = elsa.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //olaf1RB.MovePosition(olaf1RB.position + velocity * Time.fixedDeltaTime);
        o1rect.anchoredPosition = new Vector2(o1rect.anchoredPosition.x - velocity,o1rect.anchoredPosition.y);

        if(o1rect.anchoredPosition.x < -1128)
        {
            o1rect.anchoredPosition = new Vector2(1193,o1rect.anchoredPosition.y);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            elsaRect.anchoredPosition = Vector2.Lerp(ontheGround, inTheAir, Time.deltaTime);
        }
        
    }
}
