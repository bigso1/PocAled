using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MovingGroundSpecial : MonoBehaviour
{
    // Start is called before the first frame update
 

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        other.transform.SetParent(transform);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        Debug.Log("out");
        other.transform.SetParent(null);
    }
}
