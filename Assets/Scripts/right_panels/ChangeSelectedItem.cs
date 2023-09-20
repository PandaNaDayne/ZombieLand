using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSelectedItem : MonoBehaviour
{
    public Image[] icons;
    public Sprite active;
    public Sprite defaultSprite;
    
    void Start()
    {
        
    }
   

    private void OnDisable()
    {
        // Remove your listener code here
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeActiveBtn(int id)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].GetComponent<Image>().sprite = defaultSprite;
        }
        icons[id].GetComponent<Image>().sprite = active;
    }

}
