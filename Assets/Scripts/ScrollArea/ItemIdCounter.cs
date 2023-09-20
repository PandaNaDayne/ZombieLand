using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdCounter : MonoBehaviour
{
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setId(int id) 
    {
        ID = id;
    }

    public int getId() 
    {
        return ID;
    }
}
