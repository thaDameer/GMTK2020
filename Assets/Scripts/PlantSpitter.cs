using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpitter : Plants
{
    public GameObject seedBullet;
    public Transform shootPos;
    public float shootSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPlant(1);
        }
        Debug.Log(GameManager.instance.name);
        if (plantLevel != PlantLevel.MONSTER) return;
        RotateTowardsPlayer();
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Shoot");
        }

    }

    public void RotateTowardsPlayer()
    {
        var relativePos = GameManager.instance.player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime);
    }
    public float yOffset = 1f;
    public void Shoot()
    {
        var playerPos = GameManager.instance.player.transform.position;
        playerPos.y = yOffset;
        var shootDir =  playerPos - transform.position;
        var seedClone = Instantiate(seedBullet, shootPos);
        var seedRb = seedClone.GetComponent<Rigidbody>();
        seedRb.AddForce(shootDir * shootSpeed, ForceMode.Impulse);

    }
}

