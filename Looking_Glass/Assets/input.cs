using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class input : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
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
            Instantiate(projectile, new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z),
                transform.rotation);
        }
    }
}
