using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneScript : MonoBehaviour
{
    public static KillzoneScript kill;

    private void Start()
    {
        kill = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        StartCoroutine(ReplacePlayer());

    }

    IEnumerator ReplacePlayer()
    {
        var player = PlayerMovementScript.defaultPlayer;
        CameraFade.fader.doFade = true;
        yield return new WaitForSeconds(.3f);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = CheckPointsManager.checkPointsManager.checkpoint.position;
        yield return null;
        CameraFade.fader.doFade = false;
        player.GetComponent<CharacterController>().enabled = true;
    }
}
