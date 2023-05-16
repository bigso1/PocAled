using UnityEngine;

public class CameleonInvisible : Interactable
{
    [SerializeField] private float initInvisibleFxCd = 6;
    private float invisibleFxCd;
    private bool invisibleFxReady;
    private MeshRenderer mySprite;
    [SerializeField] private float hintDistance;
    [SerializeField] GameObject stunFx;
    [SerializeField] private GameObject invisibleFx;
    [SerializeField] protected float initStunCd = 10f;
    private float stunCD;
    private bool canBeStun;
    [SerializeField] private CameleonBehaviour behaviour;

    void Start()
    {
        resetTimer = originTimer;
        stunCD = initStunCd;
        mySprite = GetComponent<MeshRenderer>();
        mySprite.enabled = false;
    }

    protected override void Update()
    {
        base.Update();
        //behaviour 
        StunManagement();
        InvisibleFxManager();
        InvisibleInt();
    }

    void StunManagement()
    {
        if(canBeStun) return;
        behaviour.stunned = true;
        stunCD -= Time.deltaTime;
        if (stunCD <= 0)
        {
            canBeStun = true;
            behaviour.stunned = false;
            stunCD = initStunCd;
        }
    }

    void InvisibleFxManager()
    {
        if(invisibleFxReady) return;
        invisibleFxCd -= Time.deltaTime;
        if (invisibleFxCd <= 0)
        {
            invisibleFxReady = true;
            invisibleFxCd = initInvisibleFxCd;
        }
    }

    void InvisibleInt()
    {
        if (behaviour.CheckAggroDistance())
        {
            if(mySprite.enabled) invisibleFx.SetActive(false);
            else if (!mySprite.enabled && !invisibleFx.activeInHierarchy && invisibleFxReady)
            {
                invisibleFx.SetActive(true);
                invisibleFxReady = false;
            }
        }
        else invisibleFx.SetActive(false);
    }
    
    // Not in Update
    public override void TriggeredInteraction()
    {
        base.TriggeredInteraction();
        stunFx.SetActive(true);
        canBeStun = false;
        mySprite.enabled = true;
    }

    public override void RevertInteraction()
    {
        base.RevertInteraction();
        stunFx.SetActive(false);
        mySprite.enabled = false;
    }

}

