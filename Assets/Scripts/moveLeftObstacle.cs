using UnityEngine;

public class moveLeftObstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (gameObject.transform.localPosition.x > -12.4f)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x - 0.1f,
                                                        gameObject.transform.localPosition.y,
                                                        gameObject.transform.localPosition.z);
        }
        else if (gameObject.transform.localPosition.x < -12.4f)
        {
            gameObject.transform.localPosition = new Vector3(Random.Range(16.0f, 30.0f),
                                                        gameObject.transform.localPosition.y,
                                                        gameObject.transform.localPosition.z);
        }
        
    }
}
