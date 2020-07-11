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
        MoveTowardsRose(); 
    }


    void MoveTowardsRose()
    {
        Vector3 relativePos = transform.position - bush.transform.position;

        navigation.SetDestination(bush.transform.position);

        if (relativePos.magnitude < 3f)
        {
            navigation.isStopped = true; 
        }
        else
        {
            navigation.isStopped = false; 
        }


    }
}
