using System;
using UnityEngine;

public class Swooping : MonoBehaviour
{
    [SerializeField] private Transform ship1;
    [SerializeField] private Transform ship2;
    [SerializeField] private Transform playerCamera;

    [SerializeField] private float swoopSpeed = 0.05f;   
    [SerializeField] private float swoopHeight = 20.0f; 
    [SerializeField] private float distanceToTravel = 100.0f;  
    [SerializeField] private float swoopFrequency = 1.0f;
    [SerializeField] private float dipHeight = 5.0f;

    private float ship1Offset;
    private float ship2Offset;
    [SerializeField] private float ship1XOffset = 1.0f;
    [SerializeField] private float ship2XOffset = -1.0f;
    
    
    void Update()
    {
        MoveShip(ship1, ship1Offset, ship1XOffset);
        MoveShip(ship2, ship2Offset, ship2XOffset);
    }

    private void Start()
    {
        ship1Offset = 0.0f;
        ship2Offset = Mathf.PI;
    }

    void MoveShip(Transform ship, float offset, float shipXOffset)
    {
        float time = Time.time * swoopFrequency + offset;
        
        Vector3 startPosition = playerCamera.position + new Vector3(shipXOffset, swoopHeight, -10f);
        Vector3 endPosition = playerCamera.position + playerCamera.forward  * distanceToTravel;
        
        float t = Mathf.PingPong(time * swoopSpeed, 1.0f);
        Vector3 position = Vector3.Lerp(startPosition, endPosition, t);
        
        position.y = CalculateSwoopHeight(t);
        
        ship.position = position;
    }
    
    float CalculateSwoopHeight(float t)
    {
        // Quadratic curve formula for the swoop:
        return Mathf.Lerp(swoopHeight, swoopHeight + 10f, t) - 4 * (t - 0.5f) * (t - 0.5f) * (swoopHeight - dipHeight);
    }
}