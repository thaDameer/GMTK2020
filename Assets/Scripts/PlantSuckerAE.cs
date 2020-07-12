using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSuckerAE : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip walkingClip; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFootStep()
    {
        audioSource.PlayOneShot(walkingClip); 
    }
}
