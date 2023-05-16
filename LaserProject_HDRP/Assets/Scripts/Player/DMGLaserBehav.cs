using System.Collections.Generic;
using UnityEngine;
public class DMGLaserBehav : MonoBehaviour
{
    [SerializeField] private LayerMask masks;
    public static LayerMask Masks;
    public float dmg=5;
    private bool once;
    private Ray ray;
    private Vector3 direction;
    public int maxBounce;
    public int bounceCount;
    private float laserDuration;
    private float moduloDist;
    [SerializeField] private Camera cam;
    public float range;
    //public float intRange;
    private List<Transform> hitMarkers = new List<Transform>();
    private float remainingRange;
    //public Transform origin;
    private Vector3 endPoint;
    private Vector3 mousePos;
    private float startWidth;
    private float endWitdh;
    public Transform laserStart;
    [SerializeField] private bool switcheroo;
    [SerializeField] private LineRenderer laZer;
    private RaycastHit hit;
    [SerializeField] private Material dmgMat;
    [SerializeField] private Material intMat;

    [SerializeField] private GameObject damageFeedBack;
    //[HideInInspector] public Transform LaserHit;
    
    private Vector3 pos, dir;

    private GameObject laserObj;

    private LineRenderer laser;

    private List<Vector3> laserHits = new List<Vector3>();
    private LaserBeam beam;
    private bool beamTracker;
    void Start()
    {
        Masks = masks;
        
        cam = GetComponentInParent<Camera>();
        // Grabbed our laser.
        laZer.enabled = false;
        laZer.startWidth = 0.1f;
        laZer.endWidth = 0.1f;

        // Grab the main camera.
    }
    
    void Update()
    {
        //OriginalBeamSelector();
        BetterBeamSelector();
    }

    void BetterBeamSelector()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(1))
        {
            LaunchInteractionBeam();
            damageFeedBack.SetActive(false);
        }
        if (Input.GetMouseButton(0))
        {
            LaunchDmgBeam();
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            laZer.enabled = false;
            damageFeedBack.SetActive(false);
            //Destroy(GameObject.Find("Laser Beam"));
            once = false;
        }
        if (Input.GetMouseButtonUp(1))
        {
            //laZer.enabled = false;
            if(laserObj != null) Destroy(laserObj);
            once = false;
        }
        
    }
    void DMGlaZ()
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range,masks))
        {
            laZer.SetPosition(0, laserStart.position);
            laZer.SetPosition(1, hit.point);
            damageFeedBack.transform.position = hit.point;
            damageFeedBack.SetActive(true);
            var damageable = hit.transform.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(dmg);
            }
        }
        else
        {
            damageFeedBack.SetActive(false);
            laZer.SetPosition(0, laserStart.position);
            laZer.SetPosition(1, laserStart.position+(cam.transform.forward * range));
        }
    }

    void LaunchDmgBeam()
    {
        if (!once)
        {
            laZer.enabled = true;
            laZer.positionCount = 2;
            laZer.material = dmgMat;
            remainingRange = range;
            once = true;
        }
        if(laserObj != null) Destroy(laserObj);
        DMGlaZ();
    }
    private void LaunchInteractionBeam()
    {
        if (!once) once = true;
        if(laserObj != null) Destroy(laserObj);
           
        beam = new LaserBeam(laserStart.position, laserStart.forward, intMat);
        laserObj = beam.laserObj;
    }
    
    
    
    
    
    
    
    //---------------------------------------------functions not called ----------------------------------------------
    
    void OriginalBeamSelector()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            switcheroo = !switcheroo;
            laZer.enabled = false;
            Destroy(GameObject.Find("Laser Beam"));
            once = false;
            
        }
        
        if (Input.GetMouseButton(0))
        {
            //laZer.enabled = true;
            if (!switcheroo)
            {
                if (!once)
                {
                    laZer.enabled = true;
                    laZer.positionCount = 2;
                    laZer.material = dmgMat;
                    remainingRange = range;
                    once = true;
                }
                DMGlaZ();
            }
            else
            {
                if (!once)
                {
                    once = true;
                }
                Destroy(GameObject.Find("Laser Beam"));
                beam = new LaserBeam(laserStart.position, laserStart.forward, intMat);
                //InteractionLaZ(ray, intRange);
                //PimpInteractionLaz(ray, intRange);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            laZer.enabled = false;
            Destroy(GameObject.Find("Laser Beam"));
            once = false;
        }
    }
    

    void InteractionLaZ(Ray myRay, float myRange)
    {
        ray = new Ray(transform.position, transform.forward);
        laZer.positionCount = 1;
        laZer.SetPosition(0, transform.position);
        for (int i = 0; i < maxBounce; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingRange))
            {
                //LaserHit = hit.transform;
                laZer.positionCount += 1;
                laZer.SetPosition(laZer.positionCount - 1, hit.point);
                //range -= Vector3.Distance(ray.origin, hit.point);

                range -= hit.distance;
                /*if (hit.transform.GetComponent<Interactable>() != null)
                    hit.transform.GetComponent<Interactable>().touche=true;
                if (hit.transform.GetComponent<BouncyThingZ>() == null) return;*/

                ray = new Ray(hit.point, Vector3.Reflect(-ray.direction, hit.normal));
                Debug.DrawLine(hit.point, hit.normal);
                if (hit.collider.CompareTag("Player")) break;
            }
            else
            {
                laZer.positionCount += 1;
                laZer.SetPosition(0, laserStart.position);
                //laZer.SetPosition(laZer.positionCount-1, LaserHit.position+ray.direction*range);
                //Debug.Log("Ca marche paaaaaaaaaaaaaaaas");
            }
        }
    }

    void PimpInteractionLaz(Ray myRay, float myRange)
        {
            ray = new Ray(transform.position, transform.forward);
            laZer.positionCount = 1;
            laZer.SetPosition(0, transform.position);
            for (int i = 0; i < maxBounce; i++)
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingRange))
                {
                    laZer.positionCount += 1;
                    hitMarkers.Add(hit.transform);
                    laZer.SetPosition(laZer.positionCount - 1, hit.point);
                    //range -= Vector3.Distance(ray.origin, hit.point);

                    range -= hit.distance;
                    /*if (hit.transform.GetComponent<Interactable>() != null)
                        hit.transform.GetComponent<Interactable>().touche=true;
                    if (hit.transform.GetComponent<BouncyThingZ>() == null) return;*/

                    ray = new Ray(hit.point, Vector3.Reflect(-ray.direction, hit.normal));
                    Debug.DrawLine(hit.point, hit.normal);
                    if (hit.collider.CompareTag("Player")) break;
                }
                else
                {
                    laZer.positionCount += 1;
                    laZer.SetPosition(0, laserStart.position);
                    laZer.SetPosition(laZer.positionCount-1, ray.origin+ray.direction*range);
                    //Debug.Log("Ca marche paaaaaaaaaaaaaaaas");
                }
            }
        }
}
