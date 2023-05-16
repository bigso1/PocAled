using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesFirePoint : MonoBehaviour
{
    private Transform myTarget;
    // Start is called before the first frame update
    void Start()
    {
        myTarget = Enemies.target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
