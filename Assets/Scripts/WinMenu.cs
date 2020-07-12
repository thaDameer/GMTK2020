using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : Menu
{
    public override void Awake()
    {
        base.Awake();
        Debug.Break();
        Debug.Log("BOOM");
    }
    public override void Hide()
    {
        base.Hide();
    }
    public override void Show()
    {
        base.Show();
    }
    public override void ExitGame()
    {
        base.ExitGame();
    }
}
