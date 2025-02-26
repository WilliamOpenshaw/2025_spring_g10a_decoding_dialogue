using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerPoints : MonoBehaviour
{
    public int playerPointsNum;
    public GameObject pointsText;
    //win path screen
    public GameObject wPath;
    public GameObject lPath;
    public GameObject startScreen;
    // Start is called before the first frame update
    void Start()
    {
        playerPointsNum = 0;
        pointsText.GetComponent<TextMeshProUGUI>().text = "0";
    }

    void OnEnable()
    {
        playerPointsNum = 0;
        pointsText.GetComponent<TextMeshProUGUI>().text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if(startScreen.activeSelf == true)
        {
            playerPointsNum = 0;
        }
    }

    public void AddPoint()
    {
        if(playerPointsNum >= 10)
        {
            playerPointsNum = 0;
        }
        playerPointsNum += 1;
        pointsText.GetComponent<TextMeshProUGUI>().text = playerPointsNum.ToString();
    }
    public void PartOneCheck()
    {
        if(playerPointsNum >= 3)
        {
            wPath.SetActive(true);        
        }
        else
        {
            lPath.SetActive(true);  
        }
    }
}
