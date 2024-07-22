using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyedBoxes : MonoBehaviour
{
    private float moveSpeed = 4;
    public AudioClip destructionSoundClip;  // Campo pubblico per il suono di distruzione
    private AudioSource audioSource;

    void Start()
    {
        // Ottieni il componente AudioSource e assegna il clip di distruzione
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource non trovato sul prefab della scatola rotta!");
        }

        // Riproduci il suono di distruzione se il clip è assegnato
        if (destructionSoundClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(destructionSoundClip);
        }
        else
        {
            Debug.LogError("AudioClip non assegnato o AudioSource non trovato!");
        }

        StartCoroutine(DestroyBox());
    }

    void Update()
    {
        gameObject.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);  // Movimentazione della scatola rotta sull'asse X
    }

    IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}


