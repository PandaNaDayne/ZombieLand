using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ColorChange : MonoBehaviour
{
    public ColorSwatch colorSwatch;
    public TMP_InputField color_label;
    public GameObject[] anchors;
    public GameObject[] anchors_f;
    public GameObject gender_panel;
    public Material[] mats;
    public Material[] mats_ui;
    private int cloth_id;
    private bool gender;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setGender(bool genderr)
    {
        gender = genderr;
    }
    public void setClothId(int clothId) 
    {
        cloth_id = clothId;
    }


    public void ChangeColor()
    {
        if (gender_panel.activeSelf) 
        {
            cloth_id = mats.Length -1;
        }
        mats[cloth_id].color = colorSwatch.Color;
        mats_ui[cloth_id].color = colorSwatch.Color;
        
        TMP_Text textComponent = color_label.textComponent;
        if (textComponent != null)
        {
            textComponent.color = colorSwatch.Color;
        }
        
        
        color_label.text = ToHtmlStringRGB(colorSwatch.Color);
    }
    public static string ToHtmlStringRGB(Color color)
    {
        int r = (int)(color.r * 255);
        int g = (int)(color.g * 255);
        int b = (int)(color.b * 255);

        return string.Format("#{0:X2}{1:X2}{2:X2}", r, g, b);
    }
}
