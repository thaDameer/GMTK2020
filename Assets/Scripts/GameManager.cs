using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public RoseBush roseBush;
    public PlantHandler plantHandler;
    public CameraScript cameraScript;
    public UIHandler uiHandler;
    public Player player;
    public RectTransform roseCrosshair;


    //Level specific stuff
    public int currentPlants;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        Cursor.visible = false;
    }

    private void Update()
    {
        roseCrosshair.position = UnityEngine.Input.mousePosition;
    }


    #region SCENE_MANAGEMENT

    public void RestartScene()
    {
        Debug.Log("RESTART");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        var nextScene = SceneManager.GetActiveScene().buildIndex;
        nextScene++;
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    #endregion
}
