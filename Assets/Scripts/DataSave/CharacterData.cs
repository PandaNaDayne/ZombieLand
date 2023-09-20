using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public SerializableDictionary<string, string> anchorDict = new SerializableDictionary<string, string>();
    public bool gender;

    public CharacterData(SerializableDictionary<string, string> dict, bool gen)
    {
        this.gender = gen;
        this.anchorDict = dict;

    }
}
