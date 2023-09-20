using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenderBtn_control : MonoBehaviour
{
    public Image[] btn_images;
    public Sprite active;
    public Sprite defaultSprite;
    private Button button;
    public GameObject gender_panel;
    public GameObject right_panels_container_m;
    public GameObject right_panels_container_f;


    private void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnClick);

        }
    }

    private void OnClick()
    {
        Debug.Log("Clicked on self");
        // Добавьте свой код для выполнения действий при клике на себя
        GetComponent<Image>().sprite = active;
        for (int i = 0; i < btn_images.Length; i++)
        {
            btn_images[i].GetComponent<Image>().sprite = defaultSprite;
        }
        for (int i = 0; i < right_panels_container_m.transform.childCount; i++)
        {
            right_panels_container_m.transform.GetChild(i).transform.gameObject.SetActive(false);
        }
        for (int i = 0; i < right_panels_container_f.transform.childCount; i++)
        {
            right_panels_container_f.transform.GetChild(i).transform.gameObject.SetActive(false);
        }
        gender_panel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void deSelect() 
    {
        GetComponent<Image>().sprite = defaultSprite;
        gender_panel.SetActive(false);

    }
}
