using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Clamp Settings")]
    public float MIN_X, MAX_X, MIN_Y, MAX_Y , MIN_Z, MAX_Z;
    public float offsetY = 20, offsetZ;
    public float movementSpeed;
    public Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float smoothSpeed;
    // Update is called once per frame
    void Update()
    {
        var followPos = GameManager.instance.player.transform.position;
        followPos.y = offsetY;
        followPos.z = followPos.z + offsetZ;
        var clampedPos = new Vector3(Mathf.Clamp(followPos.x, MIN_X, MAX_X), followPos.y, Mathf.Clamp(followPos.z, MIN_Z, MAX_Z));
        transform.position = Vector3.Lerp(transform.position, clampedPos, smoothSpeed * Time.deltaTime);
    }
}
