using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUManager : MonoBehaviour
{
    public bool powerUp1 = false;

    public int secondsToWait;

    public void Set1()   //setta 1
    {
        if (powerUp1)
        {
            StopCoroutine(Wait1());
        }
        powerUp1 = true;
        Debug.Log("PowerUp1 true");
        StartCoroutine(Wait1());
    }

    public bool Get1()
    { 
        return powerUp1; 
    } 
    IEnumerator Wait1()   //aspetta tot secondi e poi spegne l'effetto di power Up
    {
        yield return new WaitForSecondsRealtime(secondsToWait);
        powerUp1 = false;
        Debug.Log("PowerUp1 false");
    }
}
