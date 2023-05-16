using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetANewLazer
{

    private Vector3 pos, dir;

    private GameObject laserObj;

    private LineRenderer lazer;

    private List<Vector3> laserHits = new List<Vector3>();
    // Start is called before the first frame update

    public void LaserBeam(Vector3 pos, Vector3 dir)
    {
        this.lazer = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser Beam";
        this.pos = pos;
        this.dir = dir;
        
        this.lazer=this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        lazer.startWidth = .2f;
        lazer.endWidth = .2f;
        CastRay(pos, dir, lazer);
    }

    void UpdateLaser()
    {
        int count = 0;
        lazer.positionCount = laserHits.Count;
        foreach (Vector3 hits in laserHits)
        {
            lazer.SetPosition(count, hits);
            count++;
        }
    }
    void CastRay(Vector3 pos, Vector3 dir, LineRenderer lazer)
    {
        laserHits.Add(pos);
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 30))
        {
            CheckHits(hit, dir, lazer);
        }
        else
        {
            laserHits.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }

    void CheckHits(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if (hitInfo.collider != null)
        {
           Vector3 pos = hitInfo.point;
           Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);
            
           CastRay(pos, dir, lazer); 
        }
        else
        {
            laserHits.Add(hitInfo.point);
            UpdateLaser();
        }

    }
}
