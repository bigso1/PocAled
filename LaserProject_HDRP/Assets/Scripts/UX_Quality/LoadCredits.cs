using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour, I_Triggerable
{
    public void TurnOn()
    {
        StartCoroutine(LoadTheCredits());
    }

    public void TurnOff()
    {
        
    }

    IEnumerator LoadTheCredits()
    {
        yield return new WaitForSeconds(0.5f);
        CameraFade.fader.doFade = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}
