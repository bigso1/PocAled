using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame2 : MonoBehaviour, I_Triggerable
{
    public LoadScene end;
    public void TurnOn()
    {
        end.LoadSelectedScene(2);
    }

    public void TurnOff()
    {
        
    }
}
