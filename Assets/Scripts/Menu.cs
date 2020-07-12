using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject container;

    public void Show()
    {
        container.SetActive(true);
    }

    public void Hide()
    {
        container.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
