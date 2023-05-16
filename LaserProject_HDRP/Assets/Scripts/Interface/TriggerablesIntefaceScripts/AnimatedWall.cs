using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimatedWall : MonoBehaviour, I_Triggerable
{
    [SerializeField] private Vector3 where = new Vector3(0,-5,0);
    [SerializeField] private float movDur = 1.5f;
    public float delay = 0;
    public void TurnOn()
    {
        MoveThis(true);
    }

    public void TurnOff()
    {
        MoveThis(false);
    }

    void MoveThis(bool on)
    {
        StartCoroutine(DelayRoutine(on));
    }
    
    IEnumerator DelayRoutine(bool on)
    {
        yield return new WaitForSeconds(delay);
        if (on)
        {
            transform.DOMove(transform.position + where,  movDur);
        }
        else
        {
            transform.DOMove(transform.position - where, movDur);
        }
    }

    
}
