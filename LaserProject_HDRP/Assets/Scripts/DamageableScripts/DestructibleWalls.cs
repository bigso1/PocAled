using System.Collections;
using UnityEngine;

public class DestructibleWalls : Damageable
{
   [SerializeField] protected float destructionDelay = 0;
   protected override void Nolife()
   {
      base.Nolife();
      StartCoroutine(Destruction());
   }

   IEnumerator Destruction()
   {
      yield return new WaitForSeconds(destructionDelay);
      Destroy(gameObject);
   }
}
