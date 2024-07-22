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

    public AudioClip powerUp1Sound;  // Campo pubblico per il suono di PowerUp1
    public AudioClip powerUp2Sound;  // Campo pubblico per il suono di PowerUp2
    public AudioClip powerUp3Sound;  // Campo pubblico per il suono di PowerUp3
    private AudioSource audioSource; // Componente AudioSource

    private void Start()
    {
        mov = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();

        // Ottieni il componente AudioSource sullo stesso GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource non trovato sul GameObject del PUManager!");
        }
    }

    public void Set1()   // Setta PowerUp1
    {
        if (powerUp1)
        {
            StopCoroutine(Wait1());
        }
        powerUp1 = true;
        PlaySound(powerUp1Sound);  // Riproduci il suono di PowerUp1
        Debug.Log("PowerUp1 true");
        StartCoroutine(Wait1());
    }

    public bool Get1()
    { 
        return powerUp1; 
    } 

    IEnumerator Wait1()   // Aspetta tot secondi e poi spegne l'effetto di PowerUp1
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
        }
        powerUp2 = true;
        PlayerLives = 99;
        PlaySound(powerUp2Sound);  // Riproduci il suono di PowerUp2
        Debug.Log("PowerUp2 true");
        StartCoroutine(Wait2());
    }

    public bool Get2()
    {
        return powerUp2;
    }

    IEnumerator Wait2()   // Aspetta tot secondi e poi spegne l'effetto di PowerUp2
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
        PlaySound(powerUp3Sound);  // Riproduci il suono di PowerUp3
        Debug.Log("PowerUp3 true");
        mov.SetJump(3.5f, 1.85f); 
        StartCoroutine(Wait3());
    }

    public bool Get3()
    {
        return powerUp3;
    }

    IEnumerator Wait3()   // Aspetta tot secondi e poi spegne l'effetto di PowerUp3
    {
        yield return new WaitForSecondsRealtime(secondsToWait);
        powerUp3 = false;
        mov.SetJumpNormal();
        Debug.Log("PowerUp3 false");
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("AudioSource o AudioClip non trovato!");
        }
    }
}
