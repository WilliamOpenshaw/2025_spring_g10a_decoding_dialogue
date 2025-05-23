using UnityEngine;

public class moveLeft : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.localPosition.x > -65f)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - 0.1f,
                                                        gameObject.transform.localPosition.y,
                                                        gameObject.transform.localPosition.z);
        }
        else if (gameObject.transform.localPosition.x < -65f)
        {
            gameObject.transform.localPosition = new Vector3(58f,
                                                        gameObject.transform.localPosition.y,
                                                        gameObject.transform.localPosition.z);
        }
        
    }
}
