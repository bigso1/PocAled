using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    public static CheckPointsManager checkPointsManager;
    public Transform checkpoint;

    private void Start()
    {
        checkPointsManager = this;
    }
}
