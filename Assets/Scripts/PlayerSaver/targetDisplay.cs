using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Camera>().targetDisplay = 999;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
