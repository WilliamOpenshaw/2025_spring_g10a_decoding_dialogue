using UnityEngine;

public class playerMove : MonoBehaviour

{
    public bool characterCanMove;
    public float speed;
    public Animator anim;
    public float height;
    public float leftBoundary;
    public float rightBoundary;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterCanMove = true;
        speed = 0.01f;
        anim = gameObject.GetComponent<Animator>();
        //height = -2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) && characterCanMove == true && gameObject.transform.localPosition.x < rightBoundary)
        {
            gameObject.transform.localPosition = new Vector3(   gameObject.transform.localPosition.x + speed,
                                                                height, 
                                                                gameObject.transform.localPosition.z);
            anim.SetBool("isWalking", true);
            //spriteRenderer.flipX = false;
        }
        else if(Input.GetKey(KeyCode.A) && characterCanMove == true && gameObject.transform.localPosition.x > leftBoundary)
        {
            gameObject.transform.localPosition = new Vector3(   gameObject.transform.localPosition.x - speed,
                                                                height, 
                                                                gameObject.transform.localPosition.z);
            anim.SetBool("isWalking", true);
            //spriteRenderer.flipX = true;
        }
        else if(Input.GetKey(KeyCode.I) && characterCanMove == true)
        {
            gameObject.transform.localPosition = new Vector3(   gameObject.transform.localPosition.x,
                                                                height, 
                                                                gameObject.transform.localPosition.z);
            anim.SetBool("isKicking", true);
        }
        else if(Input.GetKey(KeyCode.O) && characterCanMove == true)
        {
            /*
            if(anim.GetBool("isJumping") == false)
            {
                gameObject.transform.localPosition = new Vector3(   gameObject.transform.localPosition.x,
                                                                -2.0f, 
                                                                gameObject.transform.localPosition.z);
            } 
            */           
            anim.SetBool("isJumping", true);
        }
        else if(Input.GetKey(KeyCode.P) && characterCanMove == true)
        {
            gameObject.transform.localPosition = new Vector3(   gameObject.transform.localPosition.x,
                                                                height, 
                                                                gameObject.transform.localPosition.z);
            anim.SetBool("isPunching", true);
        }
        else{
            anim.SetBool("isWalking", false);
            anim.SetBool("isKicking", false);
            anim.SetBool("isPunching", false);
            anim.SetBool("isJumping", false);
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Prince jump") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Prince idle"))
            {
                gameObject.transform.localPosition = new Vector3(   gameObject.transform.localPosition.x,
                                                                height, 
                                                                gameObject.transform.localPosition.z);
            }
            
        }
    }
}
