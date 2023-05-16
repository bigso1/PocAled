using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour, I_Triggerable
{
    public List<Vector3> waypointz = new List<Vector3>();
    public float movingDur;
    public float timeBetweenMoves;
    private bool on;
    private int index;
    

    private IEnumerator MoveThis()
    {
        if(!on) yield break; 
        foreach (Vector3 t in waypointz)
        {
            if(!on) yield break; 
            transform.DOMove(waypointz[index], movingDur);
            yield return new WaitForSeconds(timeBetweenMoves);
            index++;
            if (index == waypointz.Count) index = 0;
        }
        StartCoroutine(MoveThis());
    }

    public void TurnOn()
    {
        on = true;
        StartCoroutine(MoveThis());
    }

    public void TurnOff()
    {
        on = false;
    }
}
