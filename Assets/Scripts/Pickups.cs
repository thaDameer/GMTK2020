using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField]
    private int type; // 1 = health, 2 = water
    [SerializeField]
    private int pickupLifetime = 10; 


    void Awake()
    {
        StartCoroutine("DespawnPickups"); 
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>(); 

            if(type == 1 && player.health < player._maxHealth)
            {
                player.PickupHealth();
                Destroy(this.gameObject); 
            }
            if(type == 2 && player.amountOfWater < 10)
            {
                player.PickupWater();
                Destroy(this.gameObject); 
            }
        }
    }

    IEnumerator DespawnPickups()
    {
        yield return new WaitForSeconds(pickupLifetime);

        Destroy(this.gameObject); 
    }
}
