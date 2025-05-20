using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public bool characterCanMove = true;
    public Animator anim;
    

    //public GameObject 
    
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterCanMove = true;
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) && characterCanMove == true && gameObject.transform.localPosition.x < 11.0f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.01f,gameObject.transform.position.y,gameObject.transform.position.z);
            anim.SetBool("isWalking", true);
            spriteRenderer.flipX = false;
        }
        else if(Input.GetKey(KeyCode.A) && characterCanMove == true && gameObject.transform.localPosition.x > -7.6)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.01f,gameObject.transform.position.y,gameObject.transform.position.z);
            anim.SetBool("isWalking", true);
            spriteRenderer.flipX = true;
        }
        else 
        {
            // idle
            anim.SetBool("isWalking", false);
        }
    }
}
