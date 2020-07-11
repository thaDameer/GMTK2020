using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField]
    private GameObject _healthPrefab;
    [SerializeField]
    private GameObject _waterPrefab; 


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
            if(Random.Range(0, 100) < 50)
            {
                
            }
        }
    }

}
