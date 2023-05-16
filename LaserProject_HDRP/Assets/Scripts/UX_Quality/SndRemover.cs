using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SndRemover : MonoBehaviour
{
    private CharacterController myPlayer;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myPlayer = other.GetComponent<CharacterController>();
            //ItemRemover.remov.LaunchFromExt(myPlayer);
        }
    }
}
