using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField]
    private GameObject _healthPrefab;
    [SerializeField]
    private GameObject _waterPrefab;
    [SerializeField]
    private ParticleSystem particles;

    public bool isHit = false; 


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
            Debug.Log("Grass is hit");
            if (!isHit)
            {
                Debug.Log("Grass hit is Registered"); 
                if (Random.Range(0, 100) < 30)
                {
                    Instantiate(_healthPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(_waterPrefab, transform.position, Quaternion.identity);
                }

                GetComponent<MeshRenderer>().enabled = false;
                particles.Emit(50);

                //Play audio (AudioSource.PlayClipAtPoint)

                Destroy(this.gameObject, 0.5f);

                isHit = true; 
            }
            
        }
    }

}
