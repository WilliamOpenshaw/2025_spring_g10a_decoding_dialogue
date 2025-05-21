using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour
{
    public float jumpHeight;
    public bool ascending;

    public float delay;
    //public bool descending;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpHeight = 0;
        ascending = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space) && ascending == false && gameObject.transform.localPosition.y < -0.80)
        {
            StartCoroutine(ExampleCoroutine());
            
        }

        if (ascending == true)
        {
            jumpHeight += 0.1f;
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
                                                        -0.87f + jumpHeight,
                                                        gameObject.transform.localPosition.z);
        }
        if (jumpHeight > 5.0f)
        {
            ascending = false;
            jumpHeight = 0.0f;
        }

        if (ascending == false && gameObject.transform.localPosition.y > -0.87)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x,
                                                        gameObject.transform.localPosition.y - 0.1f,
                                                        gameObject.transform.localPosition.z);
        }
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(delay);

        ascending = true;

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
