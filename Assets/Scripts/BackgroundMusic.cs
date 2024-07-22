using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance = null;

    public static BackgroundMusic Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}*/

/*public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider volumeSlider;  // Assumi che tu abbia un riferimento al VolumeSlider

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        // Carica il volume salvato o impostalo al valore di default
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        audioSource.volume = savedVolume;
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}*/

using UnityEngine.Audio;

public class BackgroundMusic : MonoBehaviour
{
    public AudioMixer audioMixer;  // Aggiungi il riferimento all'AudioMixer
    public Slider volumeSlider;    // Campo pubblico per il VolumeSlider
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on the BackgroundMusic GameObject!");
            return;
        }

        if (audioSource.clip == null)
        {
            Debug.LogError("No AudioClip assigned to the AudioSource!");
            return;
        }
        

        // Carica il volume salvato o impostalo al valore di default
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        Debug.Log("Loaded Volume: " + savedVolume);

        // Imposta il volume iniziale nell'AudioMixer
        SetVolume(savedVolume);

        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        // Avvia la riproduzione dell'audio
        audioSource.Play();
        Debug.Log("Background music should be playing now.");
    }

    public void SetVolume(float volume)
    {
        Debug.Log("SetVolume Called with: " + volume);

        // Converti il volume (0-1) in decibel (-80 a 0)
        float volumeInDecibels = Mathf.Log10(volume) * 20;
        Debug.Log("Volume in Decibels: " + volumeInDecibels);

        audioMixer.SetFloat("volume", volumeInDecibels);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}


