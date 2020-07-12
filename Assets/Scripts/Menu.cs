using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menu : MonoBehaviour
{
    public GameObject container;

    public virtual void Awake()
    {
        Hide();
    }

    public virtual void Show()
    {
        container.SetActive(true);
    }

    public virtual void Hide()
    {
        container.SetActive(false);
    }

    public virtual void ExitGame()
    {
        Application.Quit();
    }
}
