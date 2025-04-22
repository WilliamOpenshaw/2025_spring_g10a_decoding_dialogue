using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catMasterPoints : MonoBehaviour
{
    // cat pictures
    public string result;
    public GameObject catA;
    public GameObject catB;
    public GameObject catC;
    public GameObject catD;
    public GameObject catE;
    public GameObject catF;
    public GameObject catG;
    public GameObject catH;
    public GameObject catI;
    public GameObject catJ;
    public GameObject catK;
    public GameObject catL;

    //  adjectives
    public GameObject wordA;
    public GameObject wordB;
    public GameObject wordC;
    public GameObject wordD;
    public GameObject wordE;
    public GameObject wordF;
    public GameObject wordG;
    public GameObject wordH;
    public GameObject wordI;
    public GameObject wordJ;
    public GameObject wordK;
    public GameObject wordL;
    // Start is called before the first frame update
    void Start()
    {
        result = "";

        catA.SetActive(false);
        catB.SetActive(false);
        catC.SetActive(false);
        catD.SetActive(false);
        catE.SetActive(false);
        catF.SetActive(false);
        catG.SetActive(false);
        catH.SetActive(false);
        catI.SetActive(false);
        catJ.SetActive(false);
        catK.SetActive(false);
        catL.SetActive(false);

        //  adjectives
        wordA.SetActive(false);
        wordB.SetActive(false);
        wordC.SetActive(false);
        wordD.SetActive(false);
        wordE.SetActive(false);
        wordF.SetActive(false);
        wordG.SetActive(false);
        wordH.SetActive(false);
        wordI.SetActive(false);
        wordJ.SetActive(false);
        wordK.SetActive(false);
        wordL.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addA()
    {
        result += "A";
    }
    public void addB()
    {
        result += "B";
    }
    public void addC()
    {
        result += "C";
    }
    public void addD()
    {
        result += "D";
    }
    public void addE()
    {
        result += "E";
    }
    public void addF()
    {
        result += "F";
    }
    public void addG()
    {
        result += "G";
    }
    public void addH()
    {
        result += "H";
    }
    public void addI()
    {
        result += "I";
    }
    public void addJ()
    {
        result += "J";
    }
    public void addK()
    {
        result += "K";
    }
    public void addM()
    {
        result += "L";
    }
    public void resetResult()
    {
        result = "";
        catA.SetActive(false);
        catB.SetActive(false);
        catC.SetActive(false);
        catD.SetActive(false);
        catE.SetActive(false);
        catF.SetActive(false);
        catG.SetActive(false);
        catH.SetActive(false);
        catI.SetActive(false);
        catJ.SetActive(false);
        catK.SetActive(false);
        catL.SetActive(false);

        //  adjectives
        wordA.SetActive(false);
        wordB.SetActive(false);
        wordC.SetActive(false);
        wordD.SetActive(false);
        wordE.SetActive(false);
        wordF.SetActive(false);
        wordG.SetActive(false);
        wordH.SetActive(false);
        wordI.SetActive(false);
        wordJ.SetActive(false);
        wordK.SetActive(false);
        wordL.SetActive(false);
    }
    public void showAnswer()
    {
        if (result[0].ToString() == "A")
        {
            catA.SetActive(true);
            wordA.SetActive(true);
        }
        else if (result[0].ToString() == "B")
        {
            catB.SetActive(true);
            wordB.SetActive(true);
        }

        if (result[1].ToString() == "C")
        {
            catC.SetActive(true);
            wordC.SetActive(true);
        }
        else if (result[1].ToString() == "D")
        {
            catD.SetActive(true);
            wordD.SetActive(true);
        }

        if (result[2].ToString() == "E")
        {
            catE.SetActive(true);
            wordE.SetActive(true);
        }
        else if (result[2].ToString() == "F")
        {
            catF.SetActive(true);
            wordF.SetActive(true);            
        }

        if (result[3].ToString() == "G")
        {
            catG.SetActive(true);
            wordG.SetActive(true);
        }
        else if (result[3].ToString() == "H")
        {
            catH.SetActive(true);
            wordH.SetActive(true);
        }

        if (result[4].ToString() == "I")
        {
            catI.SetActive(true);
            wordI.SetActive(true);
        }
        else if (result[4].ToString() == "J")
        {
            catJ.SetActive(true);
            wordJ.SetActive(true);
        }

        if (result[5].ToString() == "K")
        {
            catK.SetActive(true);
            wordK.SetActive(true);
        }
        else if (result[5].ToString() == "L")
        {
            catL.SetActive(true);
            wordL.SetActive(true);
        }
    }
    


}