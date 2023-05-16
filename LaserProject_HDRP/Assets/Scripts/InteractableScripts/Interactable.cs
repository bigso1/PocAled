using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float moveSpeed;
    protected float resetTimer=0;
    [SerializeField] protected float originTimer=0;
    public bool once; 
    public bool usingOnce;
    [SerializeField] private bool lockState;
    public bool touche;
    public float touchedValue;
    public bool useResetTimer;
    public Vector3 hitDir;
    public Vector3 hitReference;

    public List<Interactable> forced = new List<Interactable>();
    // Update is called once per frame
    protected virtual void Update()
    {
        //ManageCounter();
        if (CheckIfStillTouched())
        {
            if (usingOnce)
            {
                if(once) return;
                once = true;
                TriggeredInteraction();
            }
        }
        if(lockState) return;
        if(!useResetTimer) return;
        ManageTimer();
    }

    protected bool CheckIfStillTouched()
    {
        touchedValue -= .5f;
        if (touchedValue <= 0)
        {
            touchedValue = 0;
            touche = false;
            return false;
        }
        else
        {
            touche = true;
            return true; 
        }
    }
    
    protected void ManageTimer()
    {
        if(CheckIfStillTouched()) return;
        if (resetTimer > 0)
        { 
            resetTimer -= Time.deltaTime;
        }
        if (resetTimer <= 0)
        {
            resetTimer = originTimer;
            RevertInteraction();
        }
    }
    
    
    public virtual void TriggeredInteraction()
    {
        if (usingOnce) if(once) return;
        once = true;
        if (forced.Count > 0)
        {
            foreach (Interactable toForce in forced)
            {
                toForce.RevertInteraction();
            }
        }
    }

    public virtual void RevertInteraction()
    {
        if(lockState) return;
        if(usingOnce) if(!once) return;
        once = false;
        if (forced.Count > 0)
        {
            foreach (Interactable toForce in forced)
            {
                toForce.TriggeredInteraction();
            }
        }
    }
}
