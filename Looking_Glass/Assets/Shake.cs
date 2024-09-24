using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shake : MonoBehaviour
{ 
    [SerializeField] private float shakeDuration = 0.5f; 
    [SerializeField] private float shakeMagnitude = 0.01f;
    [SerializeField] private float dampingSpeed = 1.0f;  

    private Transform camTransform;
    private Vector3 initialPosition;  
    private float shakeTimer = 0.0f;  

    void Start()
    {
        camTransform = transform;  
        initialPosition = camTransform.localPosition; 
    }

    void Update()
    {
        TriggerShake();
        if (shakeTimer > 0)
        {
            camTransform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            // Dampen the shake over time
            shakeTimer -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeTimer = 0f;
            camTransform.localPosition = initialPosition;
        }
    }

    // Public method to trigger the shake effect
    public void TriggerShake(float duration = 0)
    {
        shakeTimer = duration > 0 ? duration : shakeDuration;
    }
}