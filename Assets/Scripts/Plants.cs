using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    public enum PlantLevel
    {
        DIRTPILE,
        BUSH,
        MONSTER
    }
    [Header("Plant Level Objects")]
    public GameObject plantLvl1, plantLvl2, plantLvl3; 
    public PlantLevel plantLevel;
    public int health  = 1;
    public Animator animator;
    public float spawnInterval = 5;
    public TimerSimple spawnTimer;
    public ParticleSystem ps;
    bool hasSpawned = false;

   
    private void Start()
    {
        SpawnPlant(5);
    }

    public void SpawnPlant(float spawnInterval)
    {
        if (hasSpawned) return;
        this.spawnInterval = spawnInterval;
        plantLvl1.SetActive(true);
        spawnTimer = new TimerSimple(spawnInterval);
        plantLevel = PlantLevel.DIRTPILE;
        ps.Emit(10);
        StartCoroutine(PlantGrowing_CO());
        hasSpawned = true;
    }

    IEnumerator PlantGrowing_CO()
    {
        spawnTimer.Start();
        while (spawnTimer.isRunning)
        {
            if (spawnTimer.isTimerElapsed) spawnTimer.Stop();
            yield return new WaitForEndOfFrame();
        }
        LevelUp();
    }

    public virtual void Update()
    {
        if (spawnTimer.isTimerElapsed)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        switch (plantLevel)
        {
            case PlantLevel.DIRTPILE:
                ps.Emit(10);
                plantLvl1.SetActive(false);
                plantLvl2.SetActive(true);
                plantLvl3.SetActive(false);
                StartCoroutine(PlantGrowing_CO());
                plantLevel = PlantLevel.BUSH;
                break;
            case PlantLevel.BUSH:
                ps.Emit(10);
                plantLvl1.SetActive(false);
                plantLvl2.SetActive(false);
                plantLvl3.SetActive(true);
                StartCoroutine(PlantGrowing_CO());
                plantLevel = PlantLevel.MONSTER;
                break;
            case PlantLevel.MONSTER:
                ps.Emit(100);
                break;
        }
    }
    

    public virtual void UpdateHealth()
    {
        switch (plantLevel)
        {
            case PlantLevel.DIRTPILE:
                health = 1;
                break;
            case PlantLevel.BUSH:
                health = 2;
                break;
            case PlantLevel.MONSTER:
                health = 3;
                break;
        }
    }
}
