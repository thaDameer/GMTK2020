using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class PlantSucker : Plants
{
   [SerializeField]
   private float _speed = 2;

    public NavMeshAgent navigation; 

    RoseBush bush; 
    void Start()
    {
        bush = GameManager.instance.roseBushPrefab;
    }

    // Update is called once per frame
    void Update()
    {

        if (plantLevel != PlantLevel.MONSTER) return; 
        MoveTowardsRose(); 
    }


    void MoveTowardsRose()
    {
        Vector3 relativePos = transform.position - bush.transform.position;

        navigation.SetDestination(bush.transform.position);
        animator.SetTrigger("Walking"); 

        if (relativePos.magnitude < 3f)
        {
            navigation.isStopped = true;
            animator.SetTrigger("sUCKING"); 
        }
        else
        {
            navigation.isStopped = false;
            animator.SetTrigger("Walking");
        }


    }
}
