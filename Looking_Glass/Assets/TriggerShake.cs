using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShake : MonoBehaviour
{
    [SerializeField] private Shake shakeScript;

    private void OnCollisionEnter()
    {
        shakeScript.TriggerShake();
    }
}
