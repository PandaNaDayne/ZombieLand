using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderSelect : MonoBehaviour
{
    public GameObject male_model;
    public GameObject female_model;
    public GameObject left_panel;
    public GameObject gender_btn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGender(bool sel) 
    {
        if (!left_panel.activeSelf) 
        {
            left_panel.SetActive(true);
            gender_btn.SetActive(true);
        }
        CharacterInfo.gender = sel;
        male_model.transform.gameObject.SetActive(false);
        female_model.transform.gameObject.SetActive(false);
        if (sel)
        {
            male_model.transform.gameObject.SetActive(true);
        }
        else 
        {
            female_model.transform.gameObject.SetActive(true);
        }
    }
}
