using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedButton : MonoBehaviour
{
    private AudioSource audioSource; // Componente AudioSource
    public AudioClip clip; // Clip audio

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

}
