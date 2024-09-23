using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class input : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform[] projectileSpawns;
    [SerializeField] private float rotationSpeed = 5.0f;  
    [SerializeField] private float maxRotationX = 10.0f; 
    [SerializeField] private float maxRotationY = 10.0f; 

    private Vector2 screenCenter;

    void Start()
    {
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 offsetFromCenter = mousePos - screenCenter;
        
        float mouseXNormalized = (offsetFromCenter.x / Screen.width) * 2;
        float mouseYNormalized = (offsetFromCenter.y / Screen.height) * 2;
        
        float targetRotationX = Mathf.Clamp(-mouseYNormalized * maxRotationX, -maxRotationX, maxRotationX);
        float targetRotationY = Mathf.Clamp(mouseXNormalized * maxRotationY, -maxRotationY, maxRotationY);
        
        Quaternion targetRotation = Quaternion.Euler(targetRotationX, targetRotationY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        
        //shooting
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, new Vector3(projectileSpawns[0].position.x, projectileSpawns[0].position.y - .5f, projectileSpawns[0].position.z),
                projectile.transform.rotation);
            Instantiate(projectile, new Vector3(projectileSpawns[1].position.x, projectileSpawns[1].position.y - .5f, projectileSpawns[1].position.z),
                projectile.transform.rotation);
            Instantiate(projectile, new Vector3(projectileSpawns[2].position.x, projectileSpawns[2].position.y - .5f, projectileSpawns[2].position.z),
                projectile.transform.rotation);
            Instantiate(projectile, new Vector3(projectileSpawns[3].position.x, projectileSpawns[3].position.y - .5f, projectileSpawns[3].position.z),
                projectile.transform.rotation);
        }
    }
}
