using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class PlantSucker : Plants
{
   [SerializeField]
   private float _speed = 2;

    [SerializeField]
    private AudioClip _suckingClip; 

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

            if(animator.GetBool("Sucking") == false)
            {
                animator.SetBool("Sucking", true);
                GetComponent<AudioSource>().clip = _suckingClip;
                GetComponent<AudioSource>().loop = true;
                GetComponent<AudioSource>().volume = 0.2f; 
                GetComponent<AudioSource>().Play(); 
            }
            
        }
        else
        {
            navigation.isStopped = false;
            animator.SetTrigger("Walking");
            animator.SetBool("Sucking", false);
            GetComponent<AudioSource>().Stop();
        }


    }
}
