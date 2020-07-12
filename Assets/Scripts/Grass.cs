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

    private Vector3 dropSpawnPos; 


    void Start()
    {
        dropSpawnPos = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
            Player player = other.GetComponentInParent<Player>();
           

            if (!isHit && player.attacking)
            {

                float random = Random.Range(0, 100);

                if (random < 25)
                {
                    Instantiate(_healthPrefab, dropSpawnPos, Quaternion.identity);
                }
                else if(random >= 25 && random < 70)
                {
                    Instantiate(_waterPrefab, dropSpawnPos, Quaternion.identity);
                }
                else
                {

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
