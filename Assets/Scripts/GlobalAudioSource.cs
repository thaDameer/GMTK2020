using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioSource : MonoBehaviour
{
    AudioSource audioSource; 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
