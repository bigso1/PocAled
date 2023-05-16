using System;
using System.Collections;
using UnityEngine;

public class BulletScript : Interactable
{
    public Transform parent;
    public Vector3 startPos;
    private bool newMov;
    public Vector3 direction;
    public Vector3 baseRef;
    [SerializeField] private float lifeTime = 5f;
    public int myDmg;
    
    
    private void Awake()
    {
        baseRef = direction;
        StartCoroutine(LifeDur());
    }

    IEnumerator LifeDur()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    protected override void Update()
    {
        base.Update();
        MoveMe();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLifeSystem.playerLife.TakeDmg(myDmg);
        }
        else if (other.gameObject.GetComponent<Enemies>())
        {
            other.gameObject.GetComponent<Enemies>().TakeDamage(myDmg*3);
        }
        else Destroy(gameObject);
        Destroy(gameObject);
        
    }

    public override void TriggeredInteraction()
    {
        if(usingOnce) if(once) return;
        once = true;
        baseRef = direction;
    }

    private void MoveMe()   
    {
        transform.Translate(direction * Time.deltaTime * moveSpeed);
    }
    
}
