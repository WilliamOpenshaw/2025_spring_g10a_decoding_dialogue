using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool characterCanMove = true;
    public Animator anim;

    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.01f,gameObject.transform.position.y,gameObject.transform.position.z);
            anim.SetBool("isWalking", true);
            spriteRenderer.flipX = false;
        }
        if(Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.01f,gameObject.transform.position.y,gameObject.transform.position.z);
            anim.SetBool("isWalking", true);
            spriteRenderer.flipX = true;
        }
        else 
        {
            anim.SetBool("isWalking", false);
        }
    }
}
