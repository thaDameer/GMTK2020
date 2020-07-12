﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHandler : MonoBehaviour
{
    
    public PlantSpitter spitterPrefab;
    public PlantSucker suckerPrefab;

    public Transform startPosition;

    public List<Vector3> spawnPositions = new List<Vector3>(); 

    public List<Plants> plantList = new List<Plants>();

    public float minHandlerSpawnTime, maxHandlerSpawnTime;

    public float minEnemySpawnTime, maxEnemySpawnTime;

    public int level;  

    void Start()
    {
        foreach(Transform child in transform)
        {
            spawnPositions.Add(child.transform.position);
        }

        if (level == 0)
        {
            StartCoroutine("TutorialRoutine");
        }
        else if(level == 1)
        {
            StartCoroutine("SpawnPlantsLevel1Routine");
        }
        else if(level == 2)
        {
            StartCoroutine("Level2Routine"); 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetPlantAmount(int waves)
    {
        return spawnPositions.Count;
    }

    void GenerateList(int amountOfPlants)
    {

    }

    IEnumerator SpawnPlantsLevel1Routine()
    {
        foreach (Vector3 position in spawnPositions)
        {

            if (Random.Range(0, 100) <= 49)
            {
                var spitterClone = Instantiate(spitterPrefab, position, Quaternion.Euler(0,Random.Range(0, 360), 0));
                spitterClone.SpawnPlant(Random.Range(minEnemySpawnTime,maxEnemySpawnTime)); 
                
            }
            else
            {
               var suckerClone = Instantiate(suckerPrefab, position, Quaternion.identity);
                suckerClone.SpawnPlant(Random.Range(minEnemySpawnTime, maxEnemySpawnTime)); 
            }

            yield return new WaitForSeconds(Random.Range(minHandlerSpawnTime,maxHandlerSpawnTime));
        }

       
    }


    IEnumerator TutorialRoutine()
    {
        yield return new WaitForSeconds(15);

        for(int i = 0; i < spawnPositions.Count/2; i++)
        {
            var suckerClone = Instantiate(suckerPrefab, spawnPositions[i], Quaternion.identity);
            suckerClone.SpawnPlant(2);
        }

        yield return new WaitForSeconds(15);

        for (int i = spawnPositions.Count / 2; i < spawnPositions.Count; i++)
        {
            var spitterClone = Instantiate(spitterPrefab, spawnPositions[i], Quaternion.identity);
            spitterClone.SpawnPlant(2);
        }
    }

    IEnumerator Level2Routine()
    {
        

        yield return new WaitForSeconds(10);

        foreach (Vector3 position in spawnPositions)
        {

            if (Random.Range(0, 100) <= 49)
            {
                var spitterClone = Instantiate(spitterPrefab, position, Quaternion.Euler(0, Random.Range(0, 360), 0));
                spitterClone.SpawnPlant(Random.Range(minEnemySpawnTime, maxEnemySpawnTime));

            }
            else
            {
                var suckerClone = Instantiate(suckerPrefab, position, Quaternion.identity);
                suckerClone.SpawnPlant(Random.Range(minEnemySpawnTime, maxEnemySpawnTime));
            }

            yield return new WaitForSeconds(Random.Range(minHandlerSpawnTime, maxHandlerSpawnTime));
        }

        yield return new WaitForSeconds(10);

        foreach (Vector3 position in spawnPositions)
        {

            if (Random.Range(0, 100) <= 49)
            {
                var spitterClone = Instantiate(spitterPrefab, position, Quaternion.Euler(0, Random.Range(0, 360), 0));
                spitterClone.SpawnPlant(Random.Range(minEnemySpawnTime, maxEnemySpawnTime));

            }
            else
            {
                var suckerClone = Instantiate(suckerPrefab, position, Quaternion.identity);
                suckerClone.SpawnPlant(Random.Range(minEnemySpawnTime, maxEnemySpawnTime));
            }

            yield return new WaitForSeconds(Random.Range(minHandlerSpawnTime, maxHandlerSpawnTime));
        }

    }

   //public int GetPlantAmount(int waves)
   // {
   //     int numberOfEnemies = 0;

   //     for (int i = waves; i < waves; i++)
   //     {
   //         numberOfEnemies += spawnPositions.Count;
   //     }

   //     return numberOfEnemies; 
   // }

}
