using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public RoseBush roseBushPrefab;
    public PlantHandler plantHandler;
    public CameraScript cameraScript;
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
        if(currentPlants <= 0)
        {
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
}
