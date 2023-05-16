using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        CheckPointsManager.checkPointsManager.checkpoint = transform;
    }
}
