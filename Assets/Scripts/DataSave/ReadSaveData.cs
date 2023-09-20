using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ReadSaveData : MonoBehaviour
{
    public GameObject character_btn;
    public GameObject characterInfo;


    public void Start()
    {
        Debug.Log("Reading saves...");
        ReadAllSaves();
        
        //PlayerPrefs.GetString
        
    }

    public void SpawnSaves(string name) 
    {
        CharacterInfo  chInfo = characterInfo.GetComponent<CharacterInfo>();
        Debug.Log("Name: " + name + " Data" + GetDataByName(name));
        chInfo.LoadFromCash(GetDataByName(name));
        
    }

    public void ReadAllSaves()
    {
        // Retrieve the saved data
        string savesJson = PlayerPrefs.GetString("AllSaves", "[]");

        // Split the savesJson string into individual save entries
        string[] saveEntries = savesJson.Split(new string[] { "%@#$%" }, StringSplitOptions.RemoveEmptyEntries);
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            DestroyImmediate(child.gameObject);
        }
        // Process each save entry
        foreach (string saveEntry in saveEntries)
        {
            string[] saveParts = saveEntry.Split(new string[] { "%%%%%%" }, StringSplitOptions.None);
            if (saveParts.Length == 2)
            {
                string name = saveParts[0];
                string dataJson = saveParts[1];

                // Deserialize the dataJson into CharacterData
                CharacterData data = JsonUtility.FromJson<CharacterData>(dataJson);

                Debug.Log("Save key: " + name + ", Save data: " + JsonUtility.ToJson(data));
                
                GameObject characterBtn = Instantiate(character_btn, transform);
                TextMeshProUGUI textComponent = characterBtn.GetComponentInChildren<TextMeshProUGUI>();
                textComponent.text = name;
            }
        }
    }
    public CharacterData GetDataByName(string name)
    {
        // Retrieve the saved data
        string savesJson = PlayerPrefs.GetString("AllSaves", "[]");

        // Split the savesJson string into individual save entries
        string[] saveEntries = savesJson.Split(new string[] { "%@#$%" }, StringSplitOptions.RemoveEmptyEntries);

        // Process each save entry
        foreach (string saveEntry in saveEntries)
        {
            string[] saveParts = saveEntry.Split(new string[] { "%%%%%%" }, StringSplitOptions.None);
            if (saveParts.Length == 2)
            {
                string entryName = saveParts[0];
                string dataJson = saveParts[1];

                if (entryName == name)
                {
                    // Deserialize the dataJson into CharacterData
                    // Deserialize the dataJson into CharacterData
                    CharacterData data = JsonUtility.FromJson<CharacterData>(dataJson);
                    
                    return data;
                }
            }
        }

        return null; // ≈сли данные с указанным именем не найдены
    }

    // Define a structure to hold the save entry with a name and data
    [System.Serializable]
    public struct SaveEntry
    {
        public string name;
        public CharacterData data;
    }
}
