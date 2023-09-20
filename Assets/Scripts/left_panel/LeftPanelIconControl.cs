using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftPanelIconControl : MonoBehaviour
{
    public Image[] btn_images;
    public Sprite active;
    public Sprite defaultSprite;
    public GameObject right_panels_container;
    public GameObject right_panels_container_m;
    public GameObject right_panels_container_f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGenderPanels(bool gen) 
    {
        if (gen)
        {
            right_panels_container = right_panels_container_m;
        }
        else 
        {
            right_panels_container = right_panels_container_f;
        }
    }

    public void ChangeActiveBtn(int id) 
    {
        for (int i = 0; i < right_panels_container.transform.childCount; i++) 
        {
            right_panels_container.transform.GetChild(i).transform.gameObject.SetActive(false);
        }
        right_panels_container.transform.GetChild(id).transform.gameObject.SetActive(true);
        for (int i = 0; i < btn_images.Length; i++) 
        {
            btn_images[i].GetComponent<Image>().sprite = defaultSprite;
        }
        btn_images[id].GetComponent<Image>().sprite = active;
    }


}
