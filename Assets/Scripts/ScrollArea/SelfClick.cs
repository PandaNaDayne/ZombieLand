using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfClick : MonoBehaviour
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
        Debug.Log("Clicked on self");
        // �������� ���� ��� ��� ���������� �������� ��� ����� �� ����
        ScrollAreaController areaController = GameObject.FindGameObjectWithTag("ScrollViewController").GetComponent<ScrollAreaController>();
        areaController.spawnHair(GetComponent<ItemIdCounter>().getId());
    }
}
