using UnityEngine;

public class Ingredientsdetector : MonoBehaviour
{
    public GameObject lion; 
    public GameObject rhino; 
    public GameObject hyenas; 
    public GameObject elephant; 
    
    public GameObject lionHeart; 
    public GameObject rhinoDust; 
    public GameObject hyenasFur; 
    public GameObject elephantTusk; 

    public GameObject lionHeartGOT; 
    public GameObject rhinoDustGOT; 
    public GameObject hyenasFurGOT; 
    public GameObject elephantTuskGOT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lionHeart.SetActive(true);
        rhinoDust.SetActive(true);
        hyenasFur.SetActive(true);
        elephantTusk.SetActive(true);

        lionHeartGOT.SetActive(false);
        rhinoDustGOT.SetActive(false);
        hyenasFurGOT.SetActive(false);
        elephantTuskGOT.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (rhino.activeSelf == false)
        {
            rhinoDust.SetActive(false);
            rhinoDustGOT.SetActive(true);
        }
        if (hyenas.activeSelf == false)
        {
            hyenasFur.SetActive(false);
            hyenasFurGOT.SetActive(true);
        }
        if (elephant.activeSelf == false)
        {
            elephantTusk.SetActive(false);
            elephantTuskGOT.SetActive(true);
        }
        if (lion.activeSelf == false)
        {
            lionHeart.SetActive(false);
            lionHeartGOT.SetActive(true);
        }
    }
}
