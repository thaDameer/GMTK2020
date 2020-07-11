using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    public enum PlantLevel
    {
        DIRTPILE = 1,
        BUSH = 2,
        MONSTER = 3
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
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Color hitColor;
    public bool isAlive = false;
    
    
    public void SpawnPlant(float spawnInterval)
    {
        if (hasSpawned) return;
        UpdateHealth();
        this.spawnInterval = spawnInterval;
        plantLvl1.SetActive(true);
        spawnTimer = new TimerSimple(spawnInterval);
        plantLevel = PlantLevel.DIRTPILE;
        animator.SetTrigger(plantLevel.ToString());
        ps.Emit(10);
        audioSource.PlayOneShot(audioClip);
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

    public void LevelUp()
    {
        switch (plantLevel)
        {
            case PlantLevel.DIRTPILE:
                plantLvl2.SetActive(true); 

                ps.Emit(10);
                audioSource.PlayOneShot(audioClip);
                StartCoroutine(PlantGrowing_CO());
                animator.SetTrigger(PlantLevel.BUSH.ToString());
                plantLevel = PlantLevel.BUSH;
                break;
            case PlantLevel.BUSH:
                ps.Emit(10);
                audioSource.PlayOneShot(audioClip);
                plantLvl1.SetActive(false);
                plantLvl2.SetActive(false);
                plantLvl3.SetActive(true);
                StartCoroutine(PlantGrowing_CO());
                animator.SetTrigger(PlantLevel.MONSTER.ToString());
                StopCoroutine(PlantGrowing_CO());
                plantLevel = PlantLevel.MONSTER;
                break;
            case PlantLevel.MONSTER:
                
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


    public void TakeDamage(int damage)
    {
        health -= damage;
        switch (plantLevel)
        {
            case PlantLevel.DIRTPILE:
                var meshRenderer = plantLvl1.GetComponentsInChildren<MeshRenderer>();
                
                break;
            case PlantLevel.BUSH:

                break;
            case PlantLevel.MONSTER:

                break;
        }

        if(health == 0)
        {
            Destroy(this.gameObject); 
        }
    }


}
