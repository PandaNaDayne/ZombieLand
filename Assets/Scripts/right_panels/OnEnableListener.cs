using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        // Add your listener code here
        for (int i = 0; i < gameObject.transform.childCount; i++) 
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }

        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
