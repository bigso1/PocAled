using System.Collections;
using UnityEngine;

public class AtkCameleon : MonoBehaviour
{
    public float lifeDuration = .2f;
    private int myDmg = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLifeSystem.playerLife.TakeDmg(myDmg);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(Lifetime());
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifeDuration);
        Destroy(gameObject);
    }
}
