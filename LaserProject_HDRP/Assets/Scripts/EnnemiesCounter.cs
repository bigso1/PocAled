using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesCounter : MonoBehaviour
{
    public List<Transform> enemies = new List<Transform>();
    public List<Transform> toActivate = new List<Transform>();

    private void Start()
    {
        foreach (Transform e in enemies)
        {
            var getComp = e.GetComponent<Damageable>();
            getComp.myList = this;
            getComp.inList = true;
        }
    }

    public void Removal(Transform inList)
    {
        enemies.Remove(inList);
        
        if (enemies.Count < 1)
        {
            if(toActivate.Count < 1) return;
            foreach (Transform i in toActivate)
            {
                i.GetComponent<I_Triggerable>().TurnOn();
            }
        }
    }
}
