using UnityEngine;
using UnityEngine.AI;

public class Enemies : Damageable
{
    public float moveSpeed;
    [SerializeField] protected float atkRange;
    [SerializeField] protected float atkDmg;
    [SerializeField] protected float initAtkCd;
    private float atkCd;
    protected bool canAtk;
    [SerializeField] protected float aggroRange;
    protected Vector3 expectedPos;
    protected NavMeshAgent agent;
    public static Transform target;
    protected float distanceFromPlayer;
    [SerializeField] float distanceFromOther;
    
    [SerializeField] protected Transform firePoint;
    private Vector3 startPos;
    protected void Awake()
    {
        atkCd = initAtkCd;
        target = FindObjectOfType<PlayerMovementScript>().transform;
    }

    protected override void Start()
    {
        base.Start();
        startPos = transform.position;
        //agent = GetComponent<NavMeshAgent>();
        //agent.stoppingDistance = atkRange;
        expectedPos = transform.position;
    }
    protected override void Nolife()
    {
        base.Nolife();
        Destroy(gameObject);
    }
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, atkRange);
    }
    
     public bool CheckAggroDistance()
     {
         distanceFromPlayer = Vector3.Distance(transform.position, target.position);
         if (distanceFromPlayer <= aggroRange) return true;
         return false;
     }

     protected bool CheckAtkDistance()
     {
         if (distanceFromPlayer <= atkRange) return true;
         return false;
     }

     protected void AtkCdManager()
     {
         if(canAtk) return;
         atkCd -= Time.deltaTime;
         if (atkCd <= 0)
         {
             canAtk = true;
             atkCd = initAtkCd;
         }
     }

     protected void LookAtTarget()
     {
         if(CheckAggroDistance()) transform.LookAt(target, Vector3.up);
     }
     
     protected void Reset()
     {
         expectedPos = transform.position;
         transform.position = startPos;
         atkCd = initAtkCd;
         hp = fullHP;
     }

     // ----------------------------------------- With NavMesh -----------------------------------------------------
     protected void NavMeshGoToPlayer()
     {
         Debug.Log("NavmeshUpdt");
         if (CheckAggroDistance() && !NavMeshCheckProximity())
         {
             Debug.Log("onMove");
             transform.LookAt(target, Vector3.up);
             agent.SetDestination(target.position);
         }
         else if(NavMeshCheckProximity()) NavMeshRunFromPlayer();
     }

     protected bool NavMeshCheckProximity()
     {
         if (distanceFromPlayer < agent.stoppingDistance - 1) return true;
         return false;
     }

     protected void NavMeshRunFromPlayer()
     {
         agent.SetDestination(transform.position - target.position);
     }
     
     // ------------------------------------------ Without NavMesh -----------------------------------------------------
     protected void GoToTarget()
     {
         if (!CheckAggroDistance()) return;
         if(CheckAtkDistance()) return;
         expectedPos += (target.position - expectedPos).normalized * (Time.deltaTime * moveSpeed);
         transform.position = Vector3.Lerp(transform.position, expectedPos, Time.deltaTime * moveSpeed);
     }

     protected void GoToTargetBis()
     {
         if (!CheckAggroDistance()) return;
         if(CheckAtkDistance()) return;
         transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSpeed);
     }

     
}
