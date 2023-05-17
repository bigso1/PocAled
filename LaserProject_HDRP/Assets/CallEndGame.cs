using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEndGame : MonoBehaviour
{
    public LoadScene loadScene;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        
    }

    IEnumerator CallEnd()
    {
        CameraFade.fader.doFade = true;
        yield return new WaitForSeconds(1f);
        PlayerMovementScript.defaultPlayer.GetComponent<CharacterController>().enabled = false;
        loadScene.LoadSelectedScene(2);
        
    }
}
