using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class VerticalPlatforms : MonoBehaviour, I_Triggerable
{
    public List<Vector3> waypointz = new List<Vector3>();
    public float movingDur;
    public float timeBetweenMoves;
    private bool on;
    private int index;
    private bool once;


    private IEnumerator MoveThis()
    {
        if(!on) yield break; 
        foreach (Vector3 t in waypointz)
        {
            if (!on)
            {
                once = false;
                yield break;
            } 
            Debug.Log("vertical move");
            transform.DOMove(waypointz[index], movingDur);
            yield return new WaitForSeconds(timeBetweenMoves);
            index++;
            if (index == waypointz.Count) index = 0;
        }

        if (waypointz.Count <= 1) yield break;
        StartCoroutine(MoveThis());
    }

    public void TurnOn()
    {
        if(once) return;
        once = true;
        on = true;
        StartCoroutine(MoveThis());
    }

    public void TurnOff()
    {
        on = false;
        once = false;
    }
}
