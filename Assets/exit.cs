using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    // Метод, вызывающий выход из игры
    public void ExitGame()
    {
        // Приложение закрывается при вызове этого метода
        Application.Quit();
    }
}
