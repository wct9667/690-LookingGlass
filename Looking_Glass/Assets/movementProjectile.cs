using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementProjectile : MonoBehaviour
{
    [SerializeField] private float speed = -3;

    [SerializeField] private float timeUntilDestroy = 5.0f;

    private float timeAlive = 0;
    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if(timeAlive > timeUntilDestroy) Destroy(gameObject);
        transform.position += transform.forward * Time.deltaTime  * speed;
    }
}