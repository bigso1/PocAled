using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTuto : MonoBehaviour
{
    [SerializeField] private GameObject canva;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovementScript>()) canva.SetActive(true);
    }
}
