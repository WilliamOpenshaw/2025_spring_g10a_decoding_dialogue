using UnityEngine;


public class test2push : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        force = 100.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P Pressed");
            rb.AddForce(transform.up * force);
            
        }
    }
}
