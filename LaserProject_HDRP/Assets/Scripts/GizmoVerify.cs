using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoVerify : MonoBehaviour
{
   public float radius = 10f;
   public void OnDrawGizmosSelected()
   {
      Gizmos.color = Color.yellow;
      Gizmos.DrawWireSphere(transform.position, radius);
   }
}
