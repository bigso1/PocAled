using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public int tutoIndex;
    private void OnTriggerEnter(Collider other)
    {
        LoadTexts.textLoader.LoadTuto(tutoIndex);
    }
}
