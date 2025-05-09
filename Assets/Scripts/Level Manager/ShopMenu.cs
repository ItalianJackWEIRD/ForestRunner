using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopMenu : MonoBehaviour
{

    private GameObject canvasMenu; // Riferimento al giocatore
    private GameObject shopMenu; // Riferimento al pannello del negozio

    private bool shop = false; // Variabile per tenere traccia dello stato del negozio

    private GameObject buttonLife;
    private GameObject buttonLife_;
    private GameObject buttonPU;
    private GameObject buttonPU_;
    private GameObject buttonX2;
    private GameObject buttonX2_;
    private GameObject buttonSlow;
    private GameObject buttonSlow_;

    private PUManager manager; // Riferimento al PUManager
    private Score score; // Riferimento al punteggio
    private LevelGenerator levelGenerator; // Riferimento al LevelGenerator

    private AudioSource audioSource; // Componente AudioSource
    public AudioClip openShop; // Clip audio per l'apertura del negozio

    private void Start()
    {
        canvasMenu = GameObject.Find("CanvasMenu"); // Trova il CanvasMenu nella scena
        if (canvasMenu != null)
        {
            Transform shopMenuTransform = canvasMenu.transform.Find("ShopMenu"); // Cerca il figlio chiamato "ShopMenu"
            if (shopMenuTransform != null)
            {
                shopMenu = shopMenuTransform.gameObject;
                Debug.Log("ShopMenu trovato!");
            }
            else
            {
                Debug.Log("ShopMenu non trovato!");
            }
        }
        else
        {
            Debug.Log("CanvasMenu non trovato!");
        }

        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>(); // Trova il punteggio nella scena
        levelGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelGenerator>(); // Trova il LevelGenerator nella scena
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    void Update()
    {
        // aggiorni la visual dello shop
        if (shop)
            updateShopUI();
    }

    // Qui puoi aggiornare l'interfaccia utente del negozio se necessario
    private void updateShopUI()
    {
        // Check per ogni bottone se è verde o rosso (Puoi o non puoi comprare) => attiva o disattiva il bottone

        if (CheckForLife())
        {
            buttonLife.SetActive(true);
            buttonLife_.SetActive(false);
        }
        else
        {
            buttonLife.SetActive(false);
            buttonLife_.SetActive(true);
        }

        if (CheckForPU())
        {
            buttonPU.SetActive(true);
            buttonPU_.SetActive(false);
        }
        else
        {
            buttonPU.SetActive(false);
            buttonPU_.SetActive(true);
        }

        if (CheckForX2())
        {
            buttonX2.SetActive(true);
            buttonX2_.SetActive(false);
        }
        else
        {
            buttonX2.SetActive(false);
            buttonX2_.SetActive(true);
        }

        if (CheckForSlow())
        {
            buttonSlow.SetActive(true);
            buttonSlow_.SetActive(false);
        }
        else
        {
            buttonSlow.SetActive(false);
            buttonSlow_.SetActive(true);
        }

    }

    private bool CheckForLife()
    {
        return score.GetScoreInt() >= 50 && manager.GetLives() < 4; // Controlla se il giocatore ha abbastanza monete e meno di 4 vite
    }
    private bool CheckForPU()
    {
        return score.GetScoreInt() >= 50 && !manager.IsPowerUpActive(); // Controlla se il giocatore ha abbastanza monete e non ha gia comprato un powerup
    }
    private bool CheckForX2()
    {
        return score.GetScoreInt() >= 100 && !levelGenerator.scoreX2; // Controlla se il giocatore ha abbastanza monete e non ha gia comprato un x2
    }
    private bool CheckForSlow()
    {
        return score.GetScoreInt() >= 200 && !levelGenerator.slowSpeed; // Controlla se il giocatore ha abbastanza monete e non ha gia comprato un slow
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shop")) // Controlla se il GameObject ha il tag "Shop"
        {
            Debug.Log("Player entered the shop area.");
            // Qui puoi aggiungere il codice per aprire il negozio
            OpenShop();
        }
    }

    private void OpenShop()
    {
        if (shopMenu == null)
        {
            Debug.LogError("Shop panel not found!");
            return;
        }
        shopMenu.SetActive(true); // Mostra il pannello del negozio
        shop = true; // Imposta lo stato del negozio su aperto
        Time.timeScale = 0;

        PlaySound(openShop); // Riproduci il suono di apertura del negozio

        // Assegna i riferimenti ai bottoni quando il menu è attivato
        buttonLife = shopMenu.transform.Find("ButtonLife")?.gameObject;
        buttonLife_ = shopMenu.transform.Find("ButtonLife_")?.gameObject;
        buttonPU = shopMenu.transform.Find("ButtonPU")?.gameObject;
        buttonPU_ = shopMenu.transform.Find("ButtonPU_")?.gameObject;
        buttonX2 = shopMenu.transform.Find("ButtonX2")?.gameObject;
        buttonX2_ = shopMenu.transform.Find("ButtonX2_")?.gameObject;
        buttonSlow = shopMenu.transform.Find("ButtonSlow")?.gameObject;
        buttonSlow_ = shopMenu.transform.Find("ButtonSlow_")?.gameObject;
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false); // Nascondi il pannello del negozio
        shop = false; // Imposta lo stato del negozio su chiuso
        GameManager.Instance.StartCountdown();
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
