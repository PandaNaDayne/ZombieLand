using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Character()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void Map()
    {
        SceneManager.LoadScene("MapSelection");
    }

    public void MMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ECharacter()
    {
        SceneManager.LoadScene("EditorCharacter");
    }

    public void EMap()
    {
        SceneManager.LoadScene("EditorMap");
    }
}
