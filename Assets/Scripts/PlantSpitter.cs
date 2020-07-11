using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpitter : Plants
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPlant(1);
        }
    }
}

