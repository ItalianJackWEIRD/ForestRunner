using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int ScoreInt = 0;

    public AudioClip collectSoundClip;  // Campo pubblico per il suono di raccolta
    private AudioSource audioSource;    // Componente AudioSource

    private void Start()
    {
        // Ottieni il componente AudioSource sullo stesso GameObject
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    public void ScorePlusOne()
    {
        ScoreInt++;
        PlayCollectSound();  // Riproduci il suono quando il punteggio aumenta
    }

    public void ScorePlusFive() 
    { 
        ScoreInt += 5;
        PlayCollectSound();  // Riproduci il suono quando il punteggio aumenta
    }

    public string GetScore ()
    {
        return ScoreInt.ToString();
    }

    public int GetScoreInt()
    {
        return ScoreInt;
    }

    private void PlayCollectSound()
    {
        if (audioSource != null && collectSoundClip != null)
        {
            audioSource.PlayOneShot(collectSoundClip);
        }
    }
}
