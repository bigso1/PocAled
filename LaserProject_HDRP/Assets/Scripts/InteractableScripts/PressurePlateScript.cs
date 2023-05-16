using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public List<GameObject> toTrigger = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        foreach (GameObject triggerable in toTrigger)
        {
            if(triggerable==null || triggerable.GetComponent<I_Triggerable>()==null) continue;
            triggerable.GetComponent<I_Triggerable>().TurnOn();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        foreach (GameObject triggerable in toTrigger)
        {
            if(triggerable==null || triggerable.GetComponent<I_Triggerable>()==null) continue;
            triggerable.GetComponent<I_Triggerable>().TurnOff();
        }
    }
    
}
