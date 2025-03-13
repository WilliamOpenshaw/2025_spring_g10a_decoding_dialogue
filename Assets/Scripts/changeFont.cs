using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class changeFont : MonoBehaviour
{
    public TMPro.TMP_FontAsset catFont;
    public TMPro.TMP_FontAsset normalFont;    

    public TextMeshProUGUI info;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;
    public TextMeshProUGUI text7;
    public TextMeshProUGUI text8;
    public TextMeshProUGUI text9;
    public TextMeshProUGUI text10;
    public TextMeshProUGUI text11;
    public TextMeshProUGUI text12;
    public TextMeshProUGUI text13;
    public TextMeshProUGUI text14;
    public TextMeshProUGUI text15;

    public TextMeshProUGUI text16;

    public TextMeshProUGUI text17;

    public TextMeshProUGUI text18;

    public TextMeshProUGUI text19;

    // Start is called before the first frame update
    void Start()
    {
        info.font = catFont;
        text1.font = catFont;
        text2.font = catFont;
        text3.font = catFont;
        text4.font = catFont;
        text5.font = catFont;
        text6.font = catFont;
        text7.font = catFont;
        text8.font = catFont;
        text9.font = catFont;
        text10.font = catFont;
        text11.font = catFont;
        text12.font = catFont;
        text13.font = catFont;
        text14.font = catFont;
        text15.font = catFont;
        text16.font = catFont;
        text17.font = catFont;
        text18.font = catFont;
        text19.font = catFont;
    }

    // Update is called once per frame
    public void ChanegFontToggle()
    {
        if (text1.font == catFont)
        {
            info.font = normalFont;
            text1.font = normalFont;
            text2.font = normalFont;
            text3.font = normalFont;
            text4.font = normalFont;
            text5.font = normalFont;
            text6.font = normalFont;
            text7.font = normalFont;
            text8.font = normalFont;
            text9.font = normalFont;
            text10.font = normalFont;
            text11.font = normalFont;
            text12.font = normalFont;
            text13.font = normalFont;
            text14.font = normalFont;
            text15.font = normalFont;
            text16.font = normalFont;
        text17.font = normalFont;
        text18.font = normalFont;
        text19.font = normalFont;
        }
        else if (text1.font == normalFont)
        {
            info.font = catFont;
            text1.font = catFont;
            text2.font = catFont;
            text3.font = catFont;
            text4.font = catFont;
            text5.font = catFont;
            text6.font = catFont;
            text7.font = catFont;
            text8.font = catFont;
            text9.font = catFont;
            text10.font = catFont;
            text11.font = catFont;
            text12.font = catFont;
            text13.font = catFont;
            text14.font = catFont;
            text15.font = catFont;
            text15.font = catFont;
        text16.font = catFont;
        text17.font = catFont;
        text18.font = catFont;
        text19.font = catFont;
        }
    }
}
