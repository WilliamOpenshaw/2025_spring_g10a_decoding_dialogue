using UnityEngine;

public class playerMove : MonoBehaviour

{
    public bool characterCanMove;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterCanMove = true;
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) && characterCanMove == true && gameObject.transform.localPosition.x < 2.88f)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + speed,gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
            //anim.SetBool("isWalking", true);
            //spriteRenderer.flipX = false;
        }
        else if(Input.GetKey(KeyCode.A) && characterCanMove == true && gameObject.transform.localPosition.x > -2.88f)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - speed,gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
            //anim.SetBool("isWalking", true);
            //spriteRenderer.flipX = true;
        }
    }
}
