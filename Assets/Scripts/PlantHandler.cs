using System.Collections;
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

    void Start()
    {
        foreach(Transform child in transform)
        {
            spawnPositions.Add(child.transform.position);
        }


        StartCoroutine("SpawnPlantsRoutine"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetPlantAmount()
    {
        return spawnPositions.Count;
    }

    void GenerateList(int amountOfPlants)
    {

    }

    IEnumerator SpawnPlantsRoutine()
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

}
