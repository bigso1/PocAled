using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2targets : Interactable
{
    private bool lockMe;
    [SerializeField] private int myIndex;
    [SerializeField] private LinkedTargetsManager lTm;
    private bool activated;
    
    [SerializeField] private Material activatedMat;
    [SerializeField] private Material nonActivatedMat;
    private Material myMaterial;

    public List<GameObject> toTrigger = new List<GameObject>();

    private void Start()
    {
        myMaterial = GetComponent<Material>();
    }

    public void TurnTargetOn()
    {
        if(activated) return;
        activated = true;
        lockMe = true;
        GetComponent<MeshRenderer>().material = activatedMat;
        if(toTrigger.Count<1) return;
        foreach (GameObject triggerable in toTrigger)
        {
            triggerable.GetComponent<I_Triggerable>().TurnOn();
        }
        
    }

    public void TurnTargetOff()
    {
        if(!activated) return;
        activated = false;
        lockMe = false;
        GetComponent<MeshRenderer>().material = nonActivatedMat;
        if(toTrigger.Count<1) return;
        foreach (GameObject triggerable in toTrigger)
        {
            triggerable.GetComponent<I_Triggerable>().TurnOff();
        }
    }
    

    protected override void Update()
    {
        if (CheckIfStillTouched())
        {
            if(lockMe) return;
            lockMe = true;
            lTm.UpdateTargets(myIndex, true);
        }
    }
}
