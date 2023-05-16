using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitator : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float strength = 100;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float rayMaxLength = 10;
    [SerializeField] AnimationCurve strengthByDistance;
    
    Vector3 origin;
    Vector3 direction = Vector3.down;

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){DoRayWithAnimationCurve();}
//        DoRay();
        // DoRayWithAnimationCurve();
    }

    void DoRay()
    {
        origin = transform.position;
        RaycastHit hit;
        float dist;

        if (Physics.Raycast(origin, direction, out hit, rayMaxLength, layerMask))
        {
            Color distColor = Color.Lerp(Color.green, Color.red, hit.distance / rayMaxLength);
            Debug.DrawRay(origin, direction * hit.distance, distColor);
            dist = hit.distance;
        }
        else
        {
            Debug.DrawRay(origin, direction * rayMaxLength, Color.red);
            dist = rayMaxLength;
        }

        rb.AddForce(0, strength / (dist + 0.00001f), 0);
    }

    void DoRayWithAnimationCurve()
    {
        origin = transform.position;
        RaycastHit hit;
        float dist;

        if (Physics.Raycast(origin, direction, out hit, rayMaxLength, layerMask))
        {
            Color distColor = Color.Lerp(Color.green, Color.red, hit.distance / rayMaxLength);
            Debug.DrawRay(origin, direction * hit.distance, distColor);
            dist = hit.distance;
        }
        else
        {
            Debug.DrawRay(origin, direction * rayMaxLength, Color.red);
            dist = rayMaxLength;
        }

     
        rb.AddForce(0, strengthByDistance.Evaluate(dist), 0);

    }
}
