using UnityEngine;

public class Ingredientdetector : MonoBehaviour
{
    public GameObject hyenaFur;
    public GameObject rhinoDust;
    public GameObject elephantTusk;
    public GameObject riverWater;
    public GameObject lionHeart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hyenaFur.SetActive(false);
        rhinoDust.SetActive(false);
        elephantTusk.SetActive(false);
        riverWater.SetActive(false);
        lionHeart.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
