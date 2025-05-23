using UnityEngine;
using System.Collections;

public class ceo_home_wait : MonoBehaviour
{
    public GameObject ceohome;
    public GameObject plot1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    public IEnumerator WaitAndPrint()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(1.5f);
        print("WaitAndPrint " + Time.time);
        ceohome.SetActive(false);
        plot1.SetActive(true);
    }

    public IEnumerator Start()
    {
        print("Starting " + Time.time);

        // Start function WaitAndPrint as a coroutine
        yield return StartCoroutine("WaitAndPrint");
        print("Done " + Time.time);
    }

}
