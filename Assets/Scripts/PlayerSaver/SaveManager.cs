using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CI.QuickSave;
public class SaveManager : MonoBehaviour
{

    public void Save() 
    {
        QuickSaveWriter.Create("player");
    }
    public void load() 
    {
        
    }
}


