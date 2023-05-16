using System.Collections;
using UnityEngine;

public class CameleonBehaviour : Enemies
{
    public bool stunned;
    [SerializeField] private GameObject atkCollider;
    protected bool attacking;
    [SerializeField] private float preAtkDur;

    protected void Update()
    {
        if(stunned) return;
        CameleonCore();
        if(attacking) return;
        LookAtTarget();
        GoToTarget();
        //NavMeshGoToPlayer();
    }
    

    void CameleonCore()
    {
        if(PlayerLifeSystem.playerLife.hp <= 0) Reset();
        AtkCdManager();
        Atk();
    }

  

    void Atk()
    {
        if(!CheckAtkDistance()) return;
        if (!canAtk) return;
        StartCoroutine(CastAtk());
    }

    IEnumerator CastAtk()
    {
        Debug.Log("CameleonAtk");
        attacking = true;
        canAtk = false;
        yield return new WaitForSeconds(preAtkDur);
        GameObject atkInstance = Instantiate(atkCollider, firePoint);
        atkInstance.transform.rotation = firePoint.rotation;
        yield return new WaitForSeconds(0.5f);
        attacking = false;

    }

    
}
