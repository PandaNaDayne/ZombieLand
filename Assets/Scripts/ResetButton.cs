using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public GameObject anchorsGameObject;
    private GameObject[] anchors;
    // Start is called before the first frame update
    void Start()
    {
        anchors = anchorsGameObject.GetComponent<CharacterInfo>().anchorList;
        foreach (GameObject anchor in anchors) 
        {
            if (anchor.transform.childCount > 0) 
            {
                for (int i = 0; i < anchor.transform.childCount; i++) 
                {
                    Destroy(anchor.transform.GetChild(i).gameObject);
                }
            }
        }
    }
    public void ResetCustoms() 
    {
        foreach (GameObject anchor in anchors)
        {
            if (anchor.transform.childCount > 0)
            {
                for (int i = 0; i < anchor.transform.childCount; i++)
                {
                    Destroy(anchor.transform.GetChild(i).gameObject);
                }
            }
        }
    }

    
}
