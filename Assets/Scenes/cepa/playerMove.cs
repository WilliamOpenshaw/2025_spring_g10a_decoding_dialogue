using UnityEngine;

public class playerMove : MonoBehaviour

{
    public bool characterCanMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterCanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) && characterCanMove == true && gameObject.transform.localPosition.x < 110.0f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1f,gameObject.transform.position.y,gameObject.transform.position.z);
            //anim.SetBool("isWalking", true);
            //spriteRenderer.flipX = false;
        }
        else if(Input.GetKey(KeyCode.A) && characterCanMove == true && gameObject.transform.localPosition.x > -70.6)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1f,gameObject.transform.position.y,gameObject.transform.position.z);
            //anim.SetBool("isWalking", true);
            //spriteRenderer.flipX = true;
        }
    }
}
