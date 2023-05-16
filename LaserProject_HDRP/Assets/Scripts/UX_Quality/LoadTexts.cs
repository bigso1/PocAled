using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadTexts : MonoBehaviour
{
    public static LoadTexts textLoader;
    public List<CanvasGroup> toLoad = new List<CanvasGroup>();
    [SerializeField] private float step = 0.05f;
    private bool doFade;
    private int myIndex = 0;
    private bool once;
    private void Start()
    {
        textLoader = this;
    }

    private void Update()
    {
        if (doFade)
        {
            toLoad[myIndex].alpha += step;
        }
        else
        {
            toLoad[myIndex].alpha -= step;
        }
    }

    public void LoadTuto(int index)
    {
        StartCoroutine(LoadZeTuto(index));
    }
    public IEnumerator LoadZeTuto(int indexx)
    {
        if(once) yield break;
        once = true;
        myIndex = indexx;
        doFade = true;
        yield return new WaitForSeconds(4f);
        doFade = false;
        once = false;
    }
}
