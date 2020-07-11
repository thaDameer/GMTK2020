using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public  bool isAlive;
    public  Vector3 shootDirection;     
    public Rigidbody bulletRb;
    private float bulletSpeed;
    float lifetime = 1f;



    private void OnEnable()
    {
        isAlive = true;
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            lifetime -= Time.fixedDeltaTime;
            if(lifetime < 0)
            {
                isAlive = false;
            }
            bulletRb.AddForce(shootDirection * bulletSpeed, ForceMode.Acceleration);
        }
    }

    public void ShootBullet(Vector3 direction, float shootSpeed)
    {

        shootDirection = transform.position - GameManager.instance.player.transform.position;
        bulletSpeed = shootSpeed;
        shootDirection = direction;
        isAlive = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Hurt the player!
        }
    }
}
