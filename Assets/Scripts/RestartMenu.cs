using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartMenu : Menu
{
    string lostText;
    public Text text;

    public override void Awake()
    {
        base.Awake();
    }
    public override void Show()
    {
        base.Show();
        //text.text = lostText;
    }
    public void SetLostText(string textToDisplay)
    {
        lostText = textToDisplay;
        text.text = lostText;
    }
    public override void Hide()
    {
        base.Hide();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        base.Hide();
    }
}
