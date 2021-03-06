﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpitter : Plants
{
    public BulletScript seedBullet;
    public Transform shootPos;
    public float shootSpeed = 40f;
    public float shootInterval = 4f;
    private float currentTime;
    public AudioClip shootClip; 

    private void Update()
    {
        
        if (plantLevel != PlantLevel.MONSTER) return;
        RotateTowardsPlayer();
        if(currentTime >= shootInterval)
        {
            animator.SetTrigger("Shoot");
            currentTime = 0;
        }
        currentTime += Time.deltaTime;

    }

    public void RotateTowardsPlayer()
    {
        var relativePos = GameManager.instance.player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime);
    }
    
    public void Shoot_AE()
    {
        var playerPos = GameManager.instance.player.transform.position;
        
        AudioSource.PlayClipAtPoint(shootClip, transform.position); 

        var seedClone = Instantiate(seedBullet,shootPos.transform.position, Quaternion.identity);
        seedClone.ShootBullet(playerPos, shootSpeed);      

    }
}

