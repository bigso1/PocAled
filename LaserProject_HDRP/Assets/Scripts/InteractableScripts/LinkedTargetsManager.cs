using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedTargetsManager : MonoBehaviour, I_Triggerable
{
    public bool[] linkedTargets = new bool[3];
    public V2targets[] targetsArray = new V2targets[3];
    public List<I_Triggerable> toTrigger = new List<I_Triggerable>();



    public void UpdateTargets(int index, bool newBool)
    {
        
        switch (index)
        {
            case 0 :
                ManageTargets(2, index);
                linkedTargets[index] = newBool;
                break;
                
            case 1 :
                ManageTargets(0, index);
                linkedTargets[index] = newBool;
                
                break;
            case 2 :
                ManageTargets(1, index);
                ManageTargets(0, index);
                linkedTargets[index] = newBool;
                break;
        }
    }

    public void TurnOn()
    {
        foreach (V2targets targets in targetsArray)
        {
            targets.TurnTargetOff();
        }
        for (int i = 0; i < linkedTargets.Length; i++)
        {
            linkedTargets[i] = false;
        }
    }
    public void TurnOff()
    {
        
    }
    public void ManageTargets(int myIndex, int otherIndex)
    {
        targetsArray[myIndex].TurnTargetOff();
        linkedTargets[myIndex] = false;
        targetsArray[otherIndex].TurnTargetOn();
    }

  
}
