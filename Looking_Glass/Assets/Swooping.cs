using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private float shotTime;
    private Vector3 ship1PreviousPosition;
    private Vector3 ship2PreviousPosition;
    
    
    [SerializeField] private float ship1XOffset = 1.0f;
    [SerializeField] private float ship2XOffset = -1.0f;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float shotFrequency = 1.0f;

    
    
    void Update()
    {
        ship1PreviousPosition = MoveShip(ship1, ship1Offset, ship1XOffset, ship1PreviousPosition);
        ship2PreviousPosition = MoveShip(ship2, ship2Offset, ship2XOffset,  ship2PreviousPosition);
    }

    private void Start()
    {
        ship1Offset = 0.0f;
        ship2Offset = Mathf.PI;
        shotTime = 0.0f;
        ship1PreviousPosition = ship1.position;
        ship2PreviousPosition = ship2.position;
    }

    Vector3 MoveShip(Transform ship, float offset, float shipXOffset, Vector3 previousPosition)
    {
        float time = Time.time * swoopFrequency + offset;
        
        Vector3 startPosition = playerCamera.position + new Vector3(shipXOffset, swoopHeight, -10f);
        Vector3 endPosition = playerCamera.position + playerCamera.forward  * distanceToTravel;
        
        float t = Mathf.PingPong(time * swoopSpeed, 1.0f);
        Vector3 position = Vector3.Lerp(startPosition, endPosition, t);
        
        position.y = CalculateSwoopHeight(t);
        
        shotTime += Time.deltaTime;
        // look towards or away from the player
        if ( IsMovingTowardsPlayer(position, previousPosition, playerCamera.position))
        {
            ship.LookAt(playerCamera.position);

            if (shotTime > shotFrequency)
            {
                shotTime = 0;
                Instantiate(projectile, new Vector3(ship.position.x, ship.position.y, ship.position.z), new Quaternion(ship.rotation.x + Random.Range(-5,5), ship.rotation.y + Random.Range(-1,1), ship.rotation.z , ship.rotation.w));
            }
        }
        else
        {
            Vector3 lookDirection = position + (position - playerCamera.position).normalized * 10f;
            ship.LookAt(lookDirection);
        }
        
        ship.position = position;
       
        return ship.position;
    }
    
    float CalculateSwoopHeight(float t)
    {
        return Mathf.Lerp(swoopHeight, swoopHeight + 10f, t) - 4 * (t - 0.5f) * (t - 0.5f) * (swoopHeight - dipHeight);
    }
    
    bool IsMovingTowardsPlayer(Vector3 currentPosition, Vector3 previousPosition, Vector3 playerPosition)
    {
        float currentDistance = Vector3.Distance(currentPosition, playerPosition);
        float previousDistance = Vector3.Distance(previousPosition, playerPosition);
        return currentDistance < previousDistance;
    }
}