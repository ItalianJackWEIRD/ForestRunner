using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopMenu : MonoBehaviour
{

    private GameObject canvasMenu; // Riferimento al giocatore
    private GameObject shopMenu; // Riferimento al pannello del negozio

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
        Time.timeScale = 0;
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false); // Nascondi il pannello del negozio
        GameManager.Instance.StartCountdown();
    }
}
