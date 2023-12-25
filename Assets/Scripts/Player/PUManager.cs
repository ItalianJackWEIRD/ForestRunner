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

    private Movement mov;

    public int secondsToWait;

    private void Start()
    {
        mov = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

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

    public bool Get2()
    {
        return powerUp2;
    }
 
    IEnumerator Wait2()   //aspetta tot secondi e poi spegne l'effetto di power Up
    {
        yield return new WaitForSecondsRealtime(secondsToWait);
        powerUp2 = false;
        PlayerLives = PlayerLivesTemp;
        Debug.Log("PowerUp2 false");
    }

    public void Set3()
    {
        if (powerUp3)
        {
            StopCoroutine(Wait3());
        }
        powerUp3 = true;
        Debug.Log("PowerUp3 true");
        mov.SetJump(3.5f, 1.85f); 
        StartCoroutine(Wait3());
    }

    public bool Get3()
    {
        return powerUp3;
    }

    IEnumerator Wait3()   //aspetta tot secondi e poi spegne l'effetto di power Up
    {
        yield return new WaitForSecondsRealtime(secondsToWait);
        powerUp3 = false;
        mov.SetJumpNormal();
        Debug.Log("PowerUp3 false");
    }
}
