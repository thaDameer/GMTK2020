using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public RoseBush roseBushPrefab;


    public Player player;
 
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
