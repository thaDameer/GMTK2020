using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHandler : MonoBehaviour
{
    
    public PlantSpitter spitterPrefab;
    public PlantSucker suckerPrefab;

    public List<Vector3> spawnPositions = new List<Vector3>(); 


    public float minHandlerSpawnTime, maxHandlerSpawnTime;

    public float minEnemySpawnTime, maxEnemySpawnTime;

    public int level;

    public int activePlants;

    void Start()
    {
        foreach(Transform child in transform)
        {
            spawnPositions.Add(child.transform.position);
        }
        activePlants = spawnPositions.Count;

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

    public void Update()
    {
        Debug.Log(PlayerSavedBush());
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
    public bool PlayerSavedBush()
    {
        if(activePlants <= 0)
        {
            GameManager.instance.uiHandler.winMenu.Show();
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Level2Routine()
    {

        activePlants = activePlants * 2;
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

}
