using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraAE : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footSteps;


    public void FootSteps()
    {
        audioSource.PlayOneShot(footSteps[Random.Range(0,footSteps.Length)]);
    }
}
