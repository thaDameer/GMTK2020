using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public RoseBush roseBush;
    public PlantHandler plantHandler;
    public CameraScript cameraScript;
    public UIHandler uiHandler;
    public Player player;


    //Level specific stuff
    public int currentPlants;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }
    private void Update()
    {
        if (HasPlayerWon())
        {
            Debug.Log("WON!");
        }
    }

    public bool HasPlayerWon()
    {
        if(currentPlants <= 0 && roseBush.waterLevel != 0 && !player.isDead)
        {
            uiHandler.winMenu.Show();
            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {
        SetupLevel();
    }
    
    public void SetupLevel()
    {
        currentPlants = plantHandler.GetPlantAmount();
    }
    #region SCENE_MANAGEMENT

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        var nextScene = SceneManager.GetActiveScene().buildIndex;
        nextScene++;
        SceneManager.LoadScene(SceneManager.GetSceneAt(nextScene).buildIndex);
    }

    #endregion
}
