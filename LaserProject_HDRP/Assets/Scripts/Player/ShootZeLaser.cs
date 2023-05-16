using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootZeLaser : MonoBehaviour
{
    // Start is called before the first frame update

    LaserBeam beam;
    [SerializeField] private Transform firePoint; 

    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.Find("Laser Beam"));
        //beam = new LaserBeam(firePoint.position, firePoint.forward);
    }
}
