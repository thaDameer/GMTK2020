using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Clamp Settings")]
    public float MIN_X, MAX_X, MIN_Y, MAX_Y , MIN_Z, MAX_Z;
    public float offsetY = 20, offsetZ;
    public Camera mainCamera;

    
    private float shakeCounter = 0f;
    public float shakeDuration = 0.3f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    

    void OnEnable()
    {
        originalPos = mainCamera.transform.localPosition;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CameraShake();
        }
    }
    public void CameraShake()
    {
        StopCoroutine(CameraShake_CO());
        StartCoroutine(CameraShake_CO());
    }

    public IEnumerator CameraShake_CO()
    {
        shakeCounter = shakeDuration;
        while (shakeCounter > 0)
        {
            var shakePos = originalPos + Random.insideUnitSphere * shakeAmount;
            shakePos.y = originalPos.y;
            mainCamera.transform.localPosition = Vector3.Lerp(mainCamera.transform.localPosition, shakePos, shakeCounter);

            shakeCounter -= Time.deltaTime * decreaseFactor;
            yield return new WaitForEndOfFrame();
        }
            shakeCounter = 0f;
            mainCamera.transform.localPosition = originalPos;
    }
}

