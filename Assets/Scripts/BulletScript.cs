using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public  bool isAlive;
    public  Vector3 shootDirection;     
    public Rigidbody bulletRb;
    private float bulletSpeed;
    float lifetime = 3f;



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
                Destroy(this.gameObject); 
            }
            bulletRb.velocity = -shootDirection.normalized * 15 ;
            //bulletRb.AddForce(-shootDirection * 1, ForceMode.Impulse);
        }
    }

    public void ShootBullet(Vector3 direction, float shootSpeed)
    {

        shootDirection = new Vector3 (transform.position.x - GameManager.instance.player.transform.position.x, 1, transform.position.z - GameManager.instance.player.transform.position.z);
        bulletSpeed = shootSpeed;
        
        isAlive = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!isAlive) return;

        var player = other.gameObject.GetComponent<Player>();
        if (player && isAlive)
        {
            Debug.Log("HIT");
            player.PlayerDamage(2);
            isAlive = false;
            Destroy(gameObject);
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (!isAlive) return;

    //        var player = collision.gameObject.GetComponent<Player>();
    //        if (player && isAlive)
    //        {
    //            Debug.Log("HIT");
    //            player.PlayerDamage();
    //            isAlive = false;
    //        }

    //    Destroy(gameObject, .4f);
        
    //}
}
