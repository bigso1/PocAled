using System.Collections.Generic;
using UnityEngine;

public class Hover: MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float strength;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float rayMaxLength = 10;
    [SerializeField] AnimationCurve strengthByDistance;

    [SerializeField] List<Vector3> points;

    Vector3 direction = Vector3.down;
    Vector3 origin;

    void FixedUpdate()
    {
        DoRays();
    }

    void DoRays()
    {
        for (int i = 0; i < points.Count; i++)
        {
            DoRay(points[i]);
        }
    }

    void DoRay(Vector3 point)
    {
        origin = transform.TransformPoint(point);

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

        rb.AddForceAtPosition(new Vector3(0, strengthByDistance.Evaluate(dist), 0), origin);
    }
}