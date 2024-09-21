using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementProjectile : MonoBehaviour
{
    [SerializeField] private float speed = -3;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime  * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyProjectile")) Destroy(gameObject);
    }
}