using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCategoryViews : MonoBehaviour
{
    public GameObject category_list;
    public GameObject category_views;
    private LayoutGroup layoutGroup;

    private void Start()
    {
        layoutGroup = GetComponent<LayoutGroup>();
        ActivateFirstButtonInLayoutGroup();
        selectCategoryView(0);
    }

    private void ActivateFirstButtonInLayoutGroup()
    {
        if (layoutGroup != null && layoutGroup.transform.childCount > 0)
        {
            Button firstButton = layoutGroup.transform.GetChild(0).GetComponent<Button>();
            if (firstButton != null)
            {
                firstButton.Select();
            }
        }
    }
    private void OnEnable()
    {
        ActivateFirstButtonInLayoutGroup();
    }

    public void selectCategoryView(int id) 
    {
        for (int i = 0; i < category_views.transform.childCount; i++) 
        {
            category_views.transform.GetChild(i).transform.gameObject.SetActive(false);
        }
        category_views.transform.GetChild(id).transform.gameObject.SetActive(true);
        
        
        
    }

    
}
