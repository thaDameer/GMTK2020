using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseBush : MonoBehaviour
{
    public float waterLevel = 100;

    [SerializeField]
    private float _droughtRate = 1;
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
        drought();
        ColorChange(); 
    }

    void drought()
    {
        waterLevel -= _droughtRate * Time.deltaTime; 
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collided"); 
        if(waterLevel <= 100)
        {
            waterLevel += _waterRate; 
        }
    }

    void ColorChange()
    {
            _mat.color = Color.Lerp(dryColor, fullHealthColor, waterLevel / 100);
    }



}
