using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShooterEnemy : Enemies
{
    public bool canMove;
    [SerializeField] private BulletScript myBullet;
    public float projectileSpeed;
    public int bulletNbr = 3;
    public float spreadAngle = 30f;
    private WaitForSeconds wait;
    public float timeBetweenBullets = 0.3f;
   

    protected override void Start()
    {
        base.Start();
        wait = new WaitForSeconds(timeBetweenBullets);
    }

    protected void Update()
    {
        Behaviour();
    }

    private void Behaviour()
    {
        if(PlayerLifeSystem.playerLife.hp <= 0) Reset();
        Movements();
        AtkCdManager();
        if (CheckAggroDistance() && CheckAtkDistance() && canAtk) {
            StartCoroutine(AlterLaunchBullets()); 
            //LaunchBullet();
        }

    }

    private void Movements()
    {
        if (CheckAggroDistance())
        { 
            LookAtTarget();
            if (canMove)
            {
                if (!MinusRange()) GoToTarget();
                else transform.position = transform.position;
            }
        }
    }

    private void LaunchBullet()
    {
        Debug.Log("Fire");
        canAtk = false;
        var bullet = Instantiate(myBullet, firePoint.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody>().AddForce((target.position-transform.position).normalized * projectileSpeed);
        bullet.baseRef = (target.position-transform.position).normalized;
    }

    IEnumerator AlterLaunchBullets()
    {
        var direction = (target.position - transform.position).normalized;
        direction = Quaternion.AngleAxis(-(spreadAngle * 0.5f), Vector3.up) * direction;
        
        canAtk = false;
        
        for (float i = 0; i < bulletNbr; i++)
        {
            Shoot(Quaternion.AngleAxis(spreadAngle * i/bulletNbr, Vector3.up) * direction);
            yield return wait;
        }
        
        void Shoot(Vector3 dir)
        {
            Instantiate(myBullet, firePoint.position, Quaternion.identity).direction = dir;
        }
    }

// Generates a set of directions that represent the spread of the bullets
List<Vector3> GenerateSpreadDirections(Vector3 direction, int numBullets, float spreadAngle)
{
    List<Vector3> directions = new List<Vector3>();
    directions.Add(direction);

    for (int i = 1; i < numBullets; i++)
    {
        Vector3 spreadDirection = Quaternion.AngleAxis(Random.Range(-spreadAngle, spreadAngle), Vector3.up) * direction;
        directions.Add(spreadDirection);
    }

    return directions;
}

    
    private bool MinusRange()
    {
        if (distanceFromPlayer <= .666f * atkRange)
        {
            canMove = false;
            return true;
        }
        canMove = true;
        return false;
    }
    

}
