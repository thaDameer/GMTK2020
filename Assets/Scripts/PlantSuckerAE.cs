using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSuckerAE : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip walkingClip;
    public AudioClip shootClip; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayShot()
    {
        audioSource.PlayOneShot(shootClip); 
    }
}
