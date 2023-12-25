using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUManager : MonoBehaviour
{
    public bool powerUp1 = false;
    public bool powerUp2 = false;
    public bool powerUp3 = false;

    public int PlayerLives;
    private int PlayerLivesTemp;

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

    public int GetLives()
    {
        return PlayerLives;
    }

    public void LifeMinus1()
    {
        PlayerLives--;
    }

    public void LifePlus1()
    {
        PlayerLives++;
    }

    public void Set2()
    {
        if (powerUp2)
        {
            StopCoroutine(Wait2());
            powerUp2 = true;
            PlayerLives = 99;
            Debug.Log("PowerUp2 true");
            StartCoroutine(Wait2());
        }
        else
        {
            powerUp2 = true;
            PlayerLivesTemp = PlayerLives;
            PlayerLives = 99;
            Debug.Log("PowerUp2 true");
            StartCoroutine(Wait2());
        }
    }

    IEnumerator Wait2()   //aspetta tot secondi e poi spegne l'effetto di power Up
    {
        yield return new WaitForSecondsRealtime(secondsToWait);
        powerUp2 = false;
        PlayerLives = PlayerLivesTemp;
        Debug.Log("PowerUp2 false");
    }
}
