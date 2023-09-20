using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterInfo : MonoBehaviour
{
    public GameObject[] assetsList, anchorList;
    public static bool gender = false; /*1=m; 0=f*/
    public static Dictionary<GameObject, string> anchorDict = new Dictionary<GameObject, string>();
    public GameObject female_model, male_model;


    private void Start()
    {
        foreach(GameObject anch in anchorList)
        {
            anchorDict.Add(anch,null);
        }
        try 
        { 
            //Load(); 
        }
        catch { }
            
    }
    public void SpawnAssets()
    {
        male_model.transform.gameObject.SetActive(false);
        female_model.transform.gameObject.SetActive(false);
        if (gender)
        {
            male_model.transform.gameObject.SetActive(true);
        }
        else
        {
            female_model.transform.gameObject.SetActive(true);
        }
        foreach (var item in anchorDict)
        {
            //Debug.Log(item.Key);
            for (int i = 0; i < assetsList.Length; i++)
            {
                if (item.Key.transform.childCount > 0) 
                {
                    Destroy(item.Key.transform.GetChild(0).transform.gameObject);
                }
                
                if (assetsList[i].GetComponent<ItemUID>().id == item.Value)
                {
                    Instantiate(assetsList[i]).transform.SetParent(item.Key.transform, false);
                    break;
                }

            }
        }
    }
    public void Load()
    {
        SerializableDictionary<string, string> loadedData = DataHandler.Load().anchorDict;
        gender = DataHandler.Load().gender;
        foreach (var item in loadedData)
        {
            GameObject foundAnch = anchorList.Where(obj => obj.name == item.Key).SingleOrDefault();
            if (foundAnch != null)
            {
                anchorDict[foundAnch] =  item.Value;
                //Debug.Log(item.Value);
            }

        }
        SpawnAssets();
    }
    public void LoadFromCash(CharacterData data)
    {
        Debug.Log("LoadFromCash...");
        SerializableDictionary<string, string> loadedData = data.anchorDict;
        gender = data.gender;

        foreach (var item in loadedData)
        {
            GameObject foundAnch = anchorList.FirstOrDefault(obj => obj.name == item.Key);
            if (foundAnch != null)
            {
                anchorDict[foundAnch] = item.Value;
                Debug.Log(item.Value);
            }
        }

        SpawnAssets();
    }


    public void Save()
    {
        SerializableDictionary<string, string> saveDict = new SerializableDictionary<string, string>();
        foreach (var item in anchorDict)
        {
            saveDict.Add(item.Key.name, item.Value);
        }
        CharacterData saveData = new CharacterData(saveDict, gender);
        DataHandler.Save(saveData);
    }


}
