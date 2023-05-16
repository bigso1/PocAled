using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public List<I_Triggerable> toTrigger = new List<I_Triggerable>();

    [SerializeField] bool entrance;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        if (entrance)
        {
            foreach (I_Triggerable t in toTrigger)
            {
                t.TurnOn();
            }
        }
        else
        {
            foreach (I_Triggerable t in toTrigger)
            {
                t.TurnOff();
            }
        }
    }
    
    
}
