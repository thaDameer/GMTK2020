using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public RectTransform waterLevel;
    public Slider healthSlider;
    public RestartMenu restartMenu;
    public WinMenu winMenu; 


    public void UpdateHealth(int currentHealth)
    {

        healthSlider.value = currentHealth;
    }

    public void UpdateWaterLevelUI(float currentWaterLevel)
    {
        var roundedWaterLvl = currentWaterLevel / 10;
        roundedWaterLvl = Mathf.Clamp(roundedWaterLvl, 0, 1);
        Vector2 imageScale = new Vector2(1, roundedWaterLvl);
        waterLevel.localScale = imageScale;
    }
}
