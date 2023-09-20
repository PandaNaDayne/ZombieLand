using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelfClickLoad : MonoBehaviour
{
    private Button button;

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
        Debug.Log("Btn for load clicked on self");
        string name = transform.GetComponentInChildren<TextMeshProUGUI>().text;
        transform.GetComponentInParent<ReadSaveData>().SpawnSaves(name);

        ;
        
    }
}
