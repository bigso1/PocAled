using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsScript : Interactable
{
    public bool reversed;
    protected bool activated;
    public List<GameObject> toTrigger;
    [SerializeField] private Material activatedMat;

    [SerializeField] private Material nonActivatedMat;

    private Material myMaterial;

    
    // Start is called before the first frame update
    

    public override void RevertInteraction()
    {
        base.RevertInteraction();
        activated = false;
        UpdtMat();
        if(!usingOnce) return;
        if(once) return;
        if(!reversed) DesActivateTheTriggerable();
        else ActivateTheTriggerable();
        
    }

    public override void TriggeredInteraction()
    {
        base.TriggeredInteraction();
        activated = true;
        UpdtMat();
        if(reversed) DesActivateTheTriggerable();
        else ActivateTheTriggerable();
    }

    protected void ActivateTheTriggerable()
    {
        if(toTrigger.Count < 1) return;
        foreach (GameObject triggerable in toTrigger)
        {
            if(triggerable==null) continue;
            triggerable.GetComponent<I_Triggerable>().TurnOn();
        }
       
    }
    protected void DesActivateTheTriggerable()
    {
        if(toTrigger.Count < 1) return;
        foreach (GameObject triggerable in toTrigger)
        {
            if(triggerable==null) continue;
            triggerable.GetComponent<I_Triggerable>().TurnOff();
        }
       
    }
    protected void ManageMat()
    {
        if (activated) myMaterial = activatedMat;
        else myMaterial = nonActivatedMat;
        
    }

    protected void UpdtMat()
    {
        ManageMat();
        GetComponent<MeshRenderer>().material = myMaterial;
    }
}
