using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour
{
    public static CameraFade fader;
    public CanvasGroup blackSquare;
    private float alphaSquare;
    [SerializeField] private float step = .1f;
    public bool doFade;

    private void Start()
    {
        fader = this;
    }

    private void Update()
    {
        alphaSquare = Mathf.Clamp(alphaSquare, 0, 1);
        if (doFade)
        {
            alphaSquare += step;
            blackSquare.alpha = alphaSquare;
        }
        else
        {
            alphaSquare -= step;
            blackSquare.alpha = alphaSquare;
        }
    }
}
