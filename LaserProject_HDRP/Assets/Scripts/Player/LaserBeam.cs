using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    public float range=12;
    public float extraRange=10f;
    public int bounce=2;
    private Vector3 pos, dir;
    //public int maxBounce;
    public GameObject laserObj { get; }
    private int count;
    private bool extralength;
    private LineRenderer lazer;
    public List<GameObject> lastThingsTouched = new List<GameObject>();
    private List<Vector3> laserHits = new List<Vector3>();
    private List<GameObject> toReset = new List<GameObject>();
    // Start is called before the first frame update
    public LaserBeam(Vector3 pos, Vector3 dir, Material mat)
    {
        this.lazer = new LineRenderer();
        this.laserObj = new GameObject();
        
        this.laserObj.name = "Laser Beam";
        
        this.pos = pos;
        this.dir = dir;
        
        this.lazer=this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        lazer.startWidth = .1f;
        lazer.endWidth = .1f;
        this.lazer.material = mat;
        CastRay(pos, dir, lazer, range);
    }

    void UpdateLaser()
    {
        count = 0;
        lazer.positionCount = laserHits.Count;
        foreach (Vector3 hits in laserHits)
        {
            bounce -= 1;
            lazer.SetPosition(count, hits);
            count++;
        }
    }
    
    void CheckHits(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if (hitInfo.collider != null && Tags.CompareTags("Bouncer", hitInfo.transform.gameObject) && bounce>0)
        {
            bounce -= 1;
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);
            
            CastRay(pos, dir, lazer, extraRange);
        }
        else
        {
            laserHits.Add(hitInfo.point);
            UpdateLaser();
        }
    }
    
    void CastRay(Vector3 position, Vector3 direct, LineRenderer laser, float rayRange)
    {
        laserHits.Add(position);
        Ray ray = new Ray(position, direct);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayRange,DMGLaserBehav.Masks))
        {
            var interactable = hit.transform.GetComponent<Interactable>();
            var bullet = hit.transform.GetComponent<BulletScript>();
            if (interactable != null)
            {
                lastThingsTouched.Add(hit.transform.gameObject);
                foreach (GameObject targets in lastThingsTouched)
                {
                    interactable.touchedValue += 1f;
                    if (bullet != null) bullet.direction = direct;
                }
            }
            CheckHits(hit, direct, laser);
        }
        else
        {
            laserHits.Add(ray.GetPoint(rayRange));
            UpdateLaser();
            //if(CheckEligibility()) return;
            lastThingsTouched.Clear();
        }
    }
    
    
}
