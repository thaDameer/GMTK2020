using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    bool isAlive;
    Vector2 shootDirection;

    private void OnEnable()
    {
        isAlive = true;
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Hurt the player!
        }
    }
}
