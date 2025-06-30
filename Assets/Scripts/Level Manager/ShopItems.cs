using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ShopItems : MonoBehaviour
{
    private PUManager manager; // Riferimento al PUManager
    private LevelGenerator levelGenerator; // Riferimento al LevelGenerator
    private Score score; // Riferimento al componente Score, se necessario

    [Header("Popup di conferma")]
    public GameObject confirmationPopup;
    public Button yesButton;
    public Button noButton;

    private Action confirmAction;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PUManager>();
        levelGenerator = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelGenerator>();
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();

        // Assicura che il popup sia nascosto all'avvio
        confirmationPopup.SetActive(false);
    }

    // Chiamata da ogni bottone "Buy"
    public void OnBuyLifeClicked() => ShowConfirmation(buyLife);
    public void OnBuyPowerUpRandomClicked() => ShowConfirmation(buyPoweUpRandom);
    public void OnBuySlowSpeedClicked() => ShowConfirmation(buySlowSpeed);
    public void OnBuyScoreX2Clicked() => ShowConfirmation(buyScoreX2);

    private void ShowConfirmation(Action action)
    {
        confirmationPopup.SetActive(true);
        confirmAction = action;

        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() =>
        {
            confirmAction?.Invoke();
            confirmationPopup.SetActive(false);
        });

        noButton.onClick.AddListener(() =>
        {
            confirmationPopup.SetActive(false);
        });
    }

    public void buyLife()
    {
        manager.LifePlus1();
        score.MenoInt(50); // Sottrae 50 punti
    }

    public void buyPoweUpRandom()
    {
        int randomPowerUp = UnityEngine.Random.Range(1, 4);
        switch (randomPowerUp)
        {
            case 1: manager.Set1(); break;
            case 2: manager.Set2(); break;
            case 3: manager.Set3(); break;
        }
        score.MenoInt(50);
    }

    public void buySlowSpeed()
    {
        levelGenerator.StartCoroutine(levelGenerator.SlowSpeed());
        score.MenoInt(200);
    }

    public void buyScoreX2()
    {
        levelGenerator.StartCoroutine(levelGenerator.ScoreX2());
        score.MenoInt(100);
    }
}
