using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUID : MonoBehaviour
{
    [SerializeField] public string id;
   
    [ContextMenu("Generate ID")]
    void GenerateId()
    {
        id = System.Guid.NewGuid().ToString();
    }
}
