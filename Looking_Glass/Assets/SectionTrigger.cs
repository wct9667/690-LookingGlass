using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject trenchSection;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("New_Trench_Trigger")) Instantiate(trenchSection, new Vector3(0, 0, 54), Quaternion.identity);
    }
}
