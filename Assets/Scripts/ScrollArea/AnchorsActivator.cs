using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnchorsActivator : MonoBehaviour
{
    CharacterInfo characterInfo;
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
        characterInfo = GameObject.FindGameObjectWithTag("character").GetComponent<CharacterInfo>();
    }

    public void ActivateAnchors() 
    {
        if (GetComponentInParent<ScrollAreaController>().anchorForDelete != null) 
        {
            GetComponentInParent<ScrollAreaController>().anchorForDelete.SetActive(true);
        }

    }

    private void OnClick()
    {
        Debug.Log("Clicked on self");

        ActivateAnchors();
    }
}
