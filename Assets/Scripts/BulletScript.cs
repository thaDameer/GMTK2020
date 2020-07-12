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
            bulletRb.velocity += -shootDirection * 3 * Time.fixedDeltaTime;
            //bulletRb.AddForce(-shootDirection * 1, ForceMode.Impulse);
        }
    }

    public void ShootBullet(Vector3 direction, float shootSpeed)
    {

        shootDirection = transform.position - GameManager.instance.player.transform.position;
        bulletSpeed = shootSpeed;
        
        isAlive = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<Player>();
            if (player && isAlive)
            {
                Debug.Log("HIT");
                player.PlayerDamage();
                isAlive = false;
            }
        }
        Destroy(gameObject, .4f);
        
    }
}
