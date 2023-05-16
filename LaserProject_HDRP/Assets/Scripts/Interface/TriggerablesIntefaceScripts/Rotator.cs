using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour, I_Triggerable
{
    [SerializeField] private Transform pivot;
    [SerializeField] private float angle = 15f;
    private Vector3 roto;
    public int axis = 1;
    public void TurnOn()
    {
        switch (axis)
        {
            case 0 :
                pivot.Rotate(Vector3.right,angle);
                break;
            case 1 :
                pivot.Rotate(Vector3.up,angle);
                break;
            case 2 :
                pivot.Rotate(Vector3.forward,angle);
                break;
        }
    }

    public void TurnOff()
    {
        
    }

   
    
}
