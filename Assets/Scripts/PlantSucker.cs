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
    [SerializeField]
    private AudioClip _walkingClip;
    [SerializeField]
    private AudioSource _walkingSource; 

    public NavMeshAgent navigation;

    [SerializeField]
    private ParticleSystem _waterStream; 

    RoseBush bush; 
    void Start()
    {
        bush = GameManager.instance.roseBush;
        
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

        if (!_walkingSource.isPlaying)
        {
            
            _walkingSource.Play();
        }


        if (relativePos.magnitude < 5f)
        {
            navigation.isStopped = true;

             
            _walkingSource.Stop(); 

            if(animator.GetBool("Sucking") == false)
            {
                animator.SetBool("Sucking", true);
                audioSource.clip = _suckingClip;
                audioSource.loop = true;
                audioSource.volume = 0.2f; 
                audioSource.Play();

                _waterStream.Play();
            }
            
        }
        else
        {
            navigation.isStopped = false;
            animator.SetTrigger("Walking");
            animator.SetBool("Sucking", false);
            audioSource.Stop();

            if (!_walkingSource.isPlaying)
            {
                _walkingSource.Play();
            }
             
        }


    }
}
