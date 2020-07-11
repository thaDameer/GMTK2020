using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchytheScript : MonoBehaviour
{
    public ParticleSystem ps;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        var enemy = other.GetComponent<Plants>();
        if (enemy)
        {
            //    Debug.Log("DAMAGE");
            //    if (GameManager.instance.player.attacking)
            //    {
            //        var hitPos = other.ClosestPointOnBounds(other.transform.position);
            //        hitPos.y += .5f;
            //        ps.transform.position = hitPos;
            //        ps.Emit(30);
            //        enemy.TakeDamage(1);
            //    }
            //
        }
      
    }
}
