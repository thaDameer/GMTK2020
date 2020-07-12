using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : Menu
{
    public override void Awake()
    {
        base.Awake();
    }
    public override void Hide()
    {
        base.Hide();
    }
    public override void Show()
    {
        Debug.Log("SHOw");
        base.Show();
    }
    public override void ExitGame()
    {
        base.ExitGame();
    }
}
