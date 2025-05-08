using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUManager : MonoBehaviour
{
    public bool powerUp1 = false;   // magnete
    public bool powerUp2 = false;   // invincibile
    public bool powerUp3 = false;   // jump boost

    private Animator animator;

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
        animator = GetComponentInChildren<Animator>();

        // Ottieni il componente AudioSource sullo stesso GameObject
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    public void Set1()   // Setta PowerUp1
    {
        if (powerUp1)
        {
            StopCoroutine(Wait1());
        }
        powerUp1 = true;
        PlaySound(powerUp1Sound);  // Riproduci il suono di PowerUp1
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
    }

    public int GetLives()
    {
        return PlayerLives;
    }

    public void LifeMinus1()
    {
        PlayerLives--;
        animator.SetTrigger("Hit");
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
    }

    public void Set3()
    {
        if (powerUp3)
        {
            StopCoroutine(Wait3());
        }
        powerUp3 = true;
        PlaySound(powerUp3Sound);  // Riproduci il suono di PowerUp3
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
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public bool IsPowerUpActive()
    {
        return powerUp1 || powerUp2 || powerUp3;
    }
}
