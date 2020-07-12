using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseBush : MonoBehaviour
{
    public float waterLevel = 100;

    [SerializeField]
    private float _droughtRate = 1;
    [SerializeField]
    private float _enemyDrainRate = 5;
    [SerializeField]
    private float _waterRate = 2;
    [SerializeField]
    private Material _mat;

    public Color fullHealthColor, dryColor;  

    private TimerSimple timer = new TimerSimple(100); 

    void Start()
    {
        _mat.color = fullHealthColor; 
    }

    void Update()
    {
        Drought();
        ColorChange(); 
    }

    void Drought()
    {
        if(waterLevel >= 0)
        {
            waterLevel -= _droughtRate * Time.deltaTime;
        }
         
    }

    void Drain()
    {
        if (waterLevel >= 0)
        {
            waterLevel -= _enemyDrainRate * Time.deltaTime;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collided"); 
        if(waterLevel <= 100)
        {
            waterLevel += _waterRate; 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {

            Drain(); 
        }
    }

    void ColorChange()
    {
            _mat.color = Color.Lerp(dryColor, fullHealthColor, waterLevel / 100);
    }



}
